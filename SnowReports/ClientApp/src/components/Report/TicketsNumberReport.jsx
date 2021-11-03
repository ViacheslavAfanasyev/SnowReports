import React, {useState, useEffect } from 'react';

import TicketStatesList from "../ReportFilters/TicketStatesList/TicketStatesList";
import SnowDatePicker from "../ReportFilters/SnowDatePicker/SnowDatePicker";
import TicketsNumberChart from "./TicketsNumberChart";
import ReportFilters from "../ReportFilters/ReportFilters";
import styles from './TicketsNumberReport.module.css'


let loadedNoResults = "No Results"



const TicketsNumberReport = () => {

    const [dataArr, setDataArr] = useState([]);
    const [charts, setCharts] = useState([]);

    //
    const weekAgo = new Date()
    weekAgo.setDate(weekAgo.getDate()-7)

    //Url parameters
    const [assignmentGroup, SetAssignmentGroup] = useState("0")
    const [dateRange, SetDateRange] = useState({startDate:weekAgo, endDate : new Date()})

    const [currentTimeZoneOffsetInHours , setCurrentTimeZoneOffsetInHours ] = useState(-new Date().getTimezoneOffset()/60);

    console.log("REACT_APP_SNOW_HOST"+process.env.REACT_APP_SNOW_HOST)



    //const [requestParameters, setRequestParameters] = useState(
    //    {startDate:new Date().toJSON().slice(0,10),
      //           endDate:endDate.toJSON().slice(0,10),
     //            assigmentGroup:'PSS_North_America_Escalation'
     //   });
    //const queryString = new URLSearchParams(requestParameters).toString();

    //const apiUrl = "/api/snowreports/GetRangedDate?"+queryString;



    const apiUrl = process.env.REACT_APP_SNOW_HOST+"/api/snowreports/GetRangedDate?startDate="+dateRange.startDate.toJSON().slice(0,10)+"&EndDate="+dateRange.endDate.toJSON().slice(0,10)+"&assigmentGroup="+assignmentGroup
        +"&timeZoneOffsetInHours="+currentTimeZoneOffsetInHours;


    async function ExportData()
    {

        const response = await fetch(apiUrl).then((r)=>{
            if (!r.ok)
            {
                loadedNoResults = "ERROR";
            }
            return r;
        })

        if (response.ok)
        {
            console.log("request - "+apiUrl);
            setDataArr(await response.json());
        }
        //setLoaded(true);
    }

    useEffect(()=>{
        ExportData();
        }, [dateRange,assignmentGroup])

    return(
    <div className={styles.Report}>
        <ReportFilters SetDateRange={SetDateRange} DateRange={dateRange} SetAssignmentGroup={SetAssignmentGroup} Charts={charts} SetCharts={setCharts}  />
        <TicketsNumberChart Source={dataArr} Charts={charts} SetCharts={setCharts}/>
    </div>
    );
};




export default TicketsNumberReport;