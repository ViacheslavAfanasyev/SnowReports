import React, {useState, useEffect } from 'react';

import TicketStatesList from "../ReportFilters/TicketStatesList/TicketStatesList";
import SnowDatePicker from "../ReportFilters/SnowDatePicker/SnowDatePicker";
import TicketsNumberChart from "./TicketsNumberChart";
import ReportFilters from "../ReportFilters/ReportFilters";
import styles from './TicketsNumberReport.module.css'

//const apiUrl = '/api/snowreports/GetRangedDate?startDate=2021-04-12&endDate=2021-11-29&state=3';
let loadedNoResults = "No Results"



const TicketsNumberReport = () => {


    const [dataArr, setDataArr] = useState([]);
    const [charts, setCharts] = useState([]);

    let endDate = new Date();
    endDate.setDate(endDate.getDate() + 7)

    const [requestParameters, setRequestParameters] = useState(
        {startDate:new Date().toJSON().slice(0,10),
                 endDate:endDate.toJSON().slice(0,10),
                 state:'3'
        });
    const queryString = new URLSearchParams(requestParameters).toString();

    const apiUrl = "/api/snowreports/GetRangedDate?"+queryString;



    async function ExportData()
    {

        const response = await fetch(apiUrl, { method: 'POST', body: JSON.stringify(requestParameters)}).then((r)=>{
            if (!r.ok)
            {
                loadedNoResults = "ERROR";
            }
            return r;
        })

        if (response.ok)
        {
            setDataArr(await response.json());
        }
        //setLoaded(true);
    }

    useEffect(()=>{
        ExportData();
        }, [requestParameters])

    return(
    <div className={styles.Report}>
        <ReportFilters SetRequestParameters={setRequestParameters} RequestParameters={requestParameters} Charts={charts} SetCharts={setCharts}  />
        <TicketsNumberChart Source={dataArr} Charts={charts} SetCharts={setCharts}/>
    </div>
    );
};




export default TicketsNumberReport;