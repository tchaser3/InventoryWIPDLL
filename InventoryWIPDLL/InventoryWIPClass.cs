/* Title:           Inventory WIP Class
 * Date:            2-27-17
 * Author:          Terry Holmes
 * 
 * Description:     This Class is for Inventory WIP */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace InventoryWIPDLL
{
    public class InventoryWIPClass
    {
        //setting up the classes
        EventLogClass TheEventLogClass = new EventLogClass();

        //setting up the data
        EmployeeSessionDataSet aEmployeeSessionDataSet;
        EmployeeSessionDataSetTableAdapters.employeesessionTableAdapter aEmployeeSessionTableAdapter;

        DataEntryWIPDataSet aDataEntryWIPDataSet;
        DataEntryWIPDataSetTableAdapters.dataentrywipTableAdapter aDataEntryWIPTableAdapter;

        FindSessionByEmployeeIDDataSet aFindSessionByEmployeeIDDataSet;
        FindSessionByEmployeeIDDataSetTableAdapters.FindSessionByEmployeeIDTableAdapter aFindSessionByEmployeeIDTableAdapter;

        FindWIPByPartIDAndWarehouseIDDataSet aFindWIPByPartIDAndWarehouseIDDataSet;
        FindWIPByPartIDAndWarehouseIDDataSetTableAdapters.FindWIPByPartIDAndWarehouseIDTableAdapter aFindWIPByPartIDAndWarehouseIDTableAdapter;

        FindWIPByProjectIDDataSet aFindWIPByProjectIDDataSet;
        FindWIPByProjectIDDataSetTableAdapters.FindWIPByProjectIDTableAdapter aFindWIPByProjectTableAdapter;

        FindWIPBySessionIDDataSet aFindWIPBySessionIDDataSet;
        FindWIPBySessionIDDataSetTableAdapters.FindWIPBySessionIDTableAdapter aFindWIPBySessionIDTableAdapter;

        InsertNewSessionDataTableAdapters.QueriesTableAdapter aInsertNewSessionTableAdapter;

        InsertDataEntryWIPDataTableAdapters.QueriesTableAdapter aInsertDataEntryWIPData;

        FindWIPByTransactionIDDataSet aFindWIPByTransactionIDDataSet;
        FindWIPByTransactionIDDataSetTableAdapters.FindWIPByTransactionIDTableAdapter aFindWIPByTransactionIDTableAdapter;

        UpdateWIPTransactionQuantityDataTableAdapters.QueriesTableAdapter aUpdateWIPTransactionQuantityTableAdapter;

        RemoveWIPEntryDataTableAdapters.QueriesTableAdapter aRemoveWIPEntryTableAdatper;

        RemoveSessionEntriesFromWIPDataTableAdapters.QueriesTableAdapter aRemoveSessionEntriesFromWIPTableAdapter;

        RemoveSessionDataTableAdapters.QueriesTableAdapter aRemoveSessionTableAdapter;

        public bool RemoveSession(int intSessionID)
        {
            bool blnFatalError = false;

            try
            {
                aRemoveSessionTableAdapter = new RemoveSessionDataTableAdapters.QueriesTableAdapter();
                aRemoveSessionTableAdapter.RemoveSession(intSessionID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory WIP Class // Remove Session " + Ex.Message);
            }

            return blnFatalError;
        }
        public bool RemoveSessionEntriesFromWIP(int intSessionID)
        {
            bool blnFatalError = false;

            try
            {
                aRemoveSessionEntriesFromWIPTableAdapter = new RemoveSessionEntriesFromWIPDataTableAdapters.QueriesTableAdapter();
                aRemoveSessionEntriesFromWIPTableAdapter.RemoveSessionEntriesFromWIP(intSessionID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory WIP Class // Remove Session Entries From WIP " + Ex.Message);
            }

            return blnFatalError;
        }
        public bool RemoveWIPEntry(int intTransactionID)
        {
            bool blnFatalError = false;

            try
            {
                aRemoveWIPEntryTableAdatper = new RemoveWIPEntryDataTableAdapters.QueriesTableAdapter();
                aRemoveWIPEntryTableAdatper.RemoveWIPEntry(intTransactionID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory WIP Class // Update WIP Transaction Quantity " + Ex.Message);
            }

            return blnFatalError;
        }
        public bool UpdateWIPTransactionQuantity(int intTransactionID, int intQuantity)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateWIPTransactionQuantityTableAdapter = new UpdateWIPTransactionQuantityDataTableAdapters.QueriesTableAdapter();
                aUpdateWIPTransactionQuantityTableAdapter.UpdateWIPTransactionQuantity(intTransactionID, intQuantity);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory WIP Class // Update WIP Transaction Quantity " + Ex.Message);
            }

            return blnFatalError;
        }
        public FindWIPByTransactionIDDataSet FindWIPByTransactionID(int intTransactionID)
        {
            try
            {
                aFindWIPByTransactionIDDataSet = new FindWIPByTransactionIDDataSet();
                aFindWIPByTransactionIDTableAdapter = new FindWIPByTransactionIDDataSetTableAdapters.FindWIPByTransactionIDTableAdapter();
                aFindWIPByTransactionIDTableAdapter.Fill(aFindWIPByTransactionIDDataSet.FindWIPByTransactionID, intTransactionID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory WIP Class // Find WIP By Transaction ID " + Ex.Message);
            }

            return aFindWIPByTransactionIDDataSet;
        }
        public bool InsertDataEntryWIP(int intSessionID, int intPartID, string strPartNumber, int intProjectID, string strDIDNumber, string strPONumber, int intWarehouseID, int intQuantity, int intEmployeeID, string strTransactionType)
        {
            bool blnFatalError = false;
            int intTransactionID = 1000;

            try
            {
                aInsertDataEntryWIPData = new InsertDataEntryWIPDataTableAdapters.QueriesTableAdapter();
                aInsertDataEntryWIPData.InsertDataEntryWIP(intTransactionID, intSessionID, intPartID, strPartNumber, intProjectID, strDIDNumber, strPONumber, intWarehouseID, intQuantity, intEmployeeID, strTransactionType);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory WIP Class // Insert Data Entry WIP " + Ex.Message);
            }

            return blnFatalError;
        }
        public bool InsertNewSession(int intEmployeeID)
        {
            //setting local variables
            bool blnFatalError = false;
           
            try
            {
                aInsertNewSessionTableAdapter = new InsertNewSessionDataTableAdapters.QueriesTableAdapter();
                aInsertNewSessionTableAdapter.InsertNewSession(intEmployeeID, true);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory WIP Class // Insert Session " + Ex.Message);
            }

            return blnFatalError;
        }
        public FindWIPBySessionIDDataSet FindWIPBySessionID(int intSessionID)
        {
            try
            {
                aFindWIPBySessionIDDataSet = new FindWIPBySessionIDDataSet();
                aFindWIPBySessionIDTableAdapter = new FindWIPBySessionIDDataSetTableAdapters.FindWIPBySessionIDTableAdapter();
                aFindWIPBySessionIDTableAdapter.Fill(aFindWIPBySessionIDDataSet.FindWIPBySessionID, intSessionID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory WIP Class // Find WIP By Session ID " + Ex.Message);
            }

            return aFindWIPBySessionIDDataSet;
        }
        public FindWIPByProjectIDDataSet FindWIPByProjectID(int intProjectID)
        {
            try
            {
                aFindWIPByProjectIDDataSet = new FindWIPByProjectIDDataSet();
                aFindWIPByProjectTableAdapter = new FindWIPByProjectIDDataSetTableAdapters.FindWIPByProjectIDTableAdapter();
                aFindWIPByProjectTableAdapter.Fill(aFindWIPByProjectIDDataSet.FindWIPByProjectID, intProjectID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory WIP Class // Find WIP By Project ID " + Ex.Message);
            }

            return aFindWIPByProjectIDDataSet;
        }
        public FindWIPByPartIDAndWarehouseIDDataSet FindWIPByPartIDAndWarehouseID(int intPartID, int intWarehouseID)
        {
            try
            {
                aFindWIPByPartIDAndWarehouseIDDataSet = new FindWIPByPartIDAndWarehouseIDDataSet();
                aFindWIPByPartIDAndWarehouseIDTableAdapter = new FindWIPByPartIDAndWarehouseIDDataSetTableAdapters.FindWIPByPartIDAndWarehouseIDTableAdapter();
                aFindWIPByPartIDAndWarehouseIDTableAdapter.Fill(aFindWIPByPartIDAndWarehouseIDDataSet.FindWIPByPartIDAndWarehouseID, intPartID, intWarehouseID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory WIP Class // Find WIP By Part ID and Warehouse IF " + Ex.Message);
            }

            return aFindWIPByPartIDAndWarehouseIDDataSet;
        }
        public FindSessionByEmployeeIDDataSet FindSessionByEmployeeID(int intEmployeeID)
        {
            try
            {
                aFindSessionByEmployeeIDDataSet = new FindSessionByEmployeeIDDataSet();
                aFindSessionByEmployeeIDTableAdapter = new FindSessionByEmployeeIDDataSetTableAdapters.FindSessionByEmployeeIDTableAdapter();
                aFindSessionByEmployeeIDTableAdapter.Fill(aFindSessionByEmployeeIDDataSet.FindSessionByEmployeeID, intEmployeeID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory WIP Class // Find Session By Employee ID " + Ex.Message);
            }

            return aFindSessionByEmployeeIDDataSet;
        }
        public DataEntryWIPDataSet GetDataEntryWIPInfo()
        {
            try
            {
                aDataEntryWIPDataSet = new DataEntryWIPDataSet();
                aDataEntryWIPTableAdapter = new DataEntryWIPDataSetTableAdapters.dataentrywipTableAdapter();
                aDataEntryWIPTableAdapter.Fill(aDataEntryWIPDataSet.dataentrywip);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory WIP Class // Get Data Entry WIP Info " + Ex.Message);
            }

            return aDataEntryWIPDataSet;
        }
        public void UpdateDataEntryWIPDB(DataEntryWIPDataSet aDataEntryWIPDataSet)
        {
            try
            {
                aDataEntryWIPTableAdapter = new DataEntryWIPDataSetTableAdapters.dataentrywipTableAdapter();
                aDataEntryWIPTableAdapter.Update(aDataEntryWIPDataSet.dataentrywip);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory WIP Class // Update Data Entry WIP DB " + Ex.Message);
            }
        }
        public EmployeeSessionDataSet GetEmployeeSessionInfo()
        {
            try
            {
                aEmployeeSessionDataSet = new EmployeeSessionDataSet();
                aEmployeeSessionTableAdapter = new EmployeeSessionDataSetTableAdapters.employeesessionTableAdapter();
                aEmployeeSessionTableAdapter.Fill(aEmployeeSessionDataSet.employeesession);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory WIP Class // Get Employee Session Info " + Ex.Message);
            }

            return aEmployeeSessionDataSet;
        }
        public void UpdateSessionDB(EmployeeSessionDataSet aEmployeeSessionDataSet)
        {
            try
            {
                aEmployeeSessionTableAdapter = new EmployeeSessionDataSetTableAdapters.employeesessionTableAdapter();
                aEmployeeSessionTableAdapter.Update(aEmployeeSessionDataSet.employeesession);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory WIP Class Update Session DB " + Ex.Message);
            }
        }
    }
}
