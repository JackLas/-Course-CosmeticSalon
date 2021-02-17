using CosmeticSalon.DB;
using CosmeticSalon.Common;
using System.Windows.Forms;
using System;

namespace CosmeticSalon.MainForms
{
    partial class FormWork
    {
        private bool pastDateDisabled = true;
        private Order cachedNextOrder = null;

        public void initScheduleTab()
        {
            initEmployeeComboBox();
            cb_sch_service.Items.AddRange(DBPresentation.instance().getServicesStringList());
            initSchedule();
            timer_main.Interval = 1000;
            timer_main.Start();
            timer_main_Tick(this, null);
        }

        private void initEmployeeComboBox()
        {
            cb_sch_employee.Items.AddRange(DBPresentation.instance().getStrListOfWorkers());
            int idx = 0;
            foreach (string str in cb_sch_employee.Items)
            {
                int id = 0;
                if (Utils.getIDFromString(str, out id))
                {
                    if (mUser.ID == id)
                    {
                        cb_sch_employee.SelectedIndex = idx;
                        cb_sch_employee.Enabled = false;
                        return;
                    }
                }

                idx++;
            }
            cb_sch_employee.SelectedIndex = -1;
            cb_sch_employee.Enabled = true;
        }

        void resetNewOrderFields()
        {
            cb_sch_service.SelectedItem = -1;
            tb_sch_client_search.Text = "";
            tb_sch_client_phone.Text = "";
            tb_sch_client_fullName.Text = "";
            rtb_sch_desc.Clear();
            tb_sch_order_basePrice.Text = "";
            tb_sch_order_addPrice.Text = "";
            tb_sch_order_duration.Text = "";
        }

        private void cb_sch_service_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cb_sch_service.SelectedIndex == -1) return;
            int id = 0;
            if (Utils.getIDFromString(cb_sch_service.SelectedItem.ToString(), out id))
            {
                tb_sch_order_basePrice.Text = 
                    DBPresentation.instance().getServicePriceByID(id).ToString();
            }
        }

        private void btn_sch_clients_search_Click(object sender, System.EventArgs e)
        {
            Client client = DBPresentation.instance().findFirstClient(
                    ((tb_sch_client_search.Text.Length > 0) ? tb_sch_client_search.Text : null));
            if (client == null) return;

            tb_sch_client_fullName.Text = client.FullName;
            tb_sch_client_phone.Text = client.Phone;
        }

        private void btn_sch_addNewOrder_Click(object sender, System.EventArgs e)
        {
            Client client = new Client();
            client.FullName = tb_sch_client_fullName.Text;
            client.Phone = tb_sch_client_phone.Text;
            DBPresentation.instance().tryToAddNewClient(client);

            int clientID = DBPresentation.instance().getClientIDByPhone(client.Phone);
            if (clientID == -1)
            {
                return;
            }

            int workerID = 0;
            if (cb_sch_employee.SelectedIndex == -1
            || !Utils.getIDFromString(cb_sch_employee.SelectedItem.ToString(), out workerID))
            {
                return;
            }

            int serviceID = 0;
            if (cb_sch_service.SelectedIndex == -1)
            {
                MessageBox.Show("Оберіть послугу");
                return;
            }
            else
            {
                if (!Utils.getIDFromString(cb_sch_service.SelectedItem.ToString(), out serviceID))
                {
                    return;
                }
            }

            int price = 0;
            int.TryParse(tb_sch_order_addPrice.Text, out price);

            int duration = 0;
            int.TryParse(tb_sch_order_duration.Text, out duration);

            if (duration == 0)
            {
                MessageBox.Show("Тривалість повина бути більше 0 хв.");
                return;
            }

            DateTime dt = new DateTime(
                dtp_sch_order_date.Value.Year,
                dtp_sch_order_date.Value.Month,
                dtp_sch_order_date.Value.Day,
                dtp_sch_order_time.Value.Hour,
                dtp_sch_order_time.Value.Minute,
                0);

            DBPresentation.instance().newOrder(
                workerID,
                clientID,
                serviceID,
                rtb_sch_desc.Text,
                price,
                dt,
                duration);

            showSuccessMessage();
            resetNewOrderFields();
            initSchedule();
            cachedNextOrder = null;
        }

        private void initSchedule()
        {
            if (cb_sch_employee.SelectedIndex < 0) return;
            int workerID = 0;
            if (!Utils.getIDFromString(cb_sch_employee.SelectedItem.ToString(), out workerID)) return;

            lb_sch_schedule.Items.Clear();
            Order[] schedule = DBPresentation.instance().getOrderForWorkerByDate(workerID, dtp_sch_currentSch.Value);
            
            foreach (Order order in schedule)
            {
                lb_sch_schedule.Items.Add(order.ToString());
            }
        }

        private void dtp_sch_currentSch_ValueChanged(object sender, System.EventArgs e)
        {
            initSchedule();
            cachedNextOrder = null;
        }

        private void dtp_sch_order_date_ValueChanged(object sender, System.EventArgs e)
        {
            if (pastDateDisabled)
            {
                if (dtp_sch_order_date.Value < DateTime.Now)
                {
                    dtp_sch_order_date.Value = DateTime.Now;
                }
            }
        }

        private void dtp_sch_order_time_ValueChanged(object sender, System.EventArgs e)
        {
            if (pastDateDisabled)
            {
                DateTime check = new DateTime(
                    dtp_sch_order_date.Value.Year, 
                    dtp_sch_order_date.Value.Month,
                    dtp_sch_order_date.Value.Day,
                    dtp_sch_order_time.Value.Hour,
                    dtp_sch_order_time.Value.Minute,
                    0);
                if (check < DateTime.Now)
                {
                    dtp_sch_order_time.Value = DateTime.Now;
                }
            }
        }

        private void cb_sch_employee_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            initSchedule();
            cachedNextOrder = null;
        }

        private void initNextOrderDesc(Order order)
        {
            rtb_sch_nextClient.Clear();
            rtb_sch_nextClient.Lines = order.toRichText();
        }

        private Order getNextOrder()
        {
            if (cachedNextOrder != null) return cachedNextOrder;

            if (cb_sch_employee.SelectedIndex < 0) return null;
            int workerID = 0;
            if (!Utils.getIDFromString(cb_sch_employee.SelectedItem.ToString(), out workerID)) return null;

            rtb_sch_nextClient.Clear();
            Order[] schedule = DBPresentation.instance().getOrderForWorkerByDate(workerID, dtp_sch_currentSch.Value);
            if (schedule.Length  < 1) return null;
            Order nextOrder = null;
            foreach (Order order in schedule)
            {
                if (order.dtStart > DateTime.Now)
                {
                    if (nextOrder == null) nextOrder = order;
                    if (order.dtStart < nextOrder.dtStart)
                    {
                        nextOrder = order;
                    }
                }
            }

            cachedNextOrder = nextOrder;
            if (cachedNextOrder != null)
            {
                initNextOrderDesc(nextOrder);
            }
            return nextOrder;
        }

        private void lb_sch_schedule_DoubleClick(object sender, System.EventArgs e)
        {
            int workerID = 0;
            if (!Utils.getIDFromString(cb_sch_employee.SelectedItem.ToString(), out workerID)) return;
            Order[] schedule = DBPresentation.instance().getOrderForWorkerByDate(workerID, dtp_sch_currentSch.Value);
            if (schedule != null && lb_sch_schedule.SelectedIndex < schedule.Length)
                MessageBox.Show(schedule[lb_sch_schedule.SelectedIndex].toRichString());
        }

        private void timer_main_Tick(object sender, System.EventArgs e)
        {
            Order order = getNextOrder();
            if (order == null)
            {
                lbl_sch_newClientTimer.Visible = false;
                return;
            }
            lbl_sch_newClientTimer.Visible = true;

            TimeSpan dtNext = order.dtStart.Subtract(DateTime.Now);

            if (dtNext.Hours == 0 && dtNext.Minutes == 0 && dtNext.Seconds == 0)
            {
                cachedNextOrder = null;
                timer_main_Tick(sender, e);
            }
            else
            {
                lbl_sch_newClientTimer.Text = dtNext.ToString(@"hh\:mm\:ss");
            }            
        }
    }
}