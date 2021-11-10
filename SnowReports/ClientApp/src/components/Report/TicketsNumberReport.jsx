import React, {useState, useEffect } from 'react';
import {ReportFiltersContext} from '../../context/ReportFiltersContext'
import TicketsNumberChart from "./TicketsNumberChart";
import ReportFilters from "../ReportFilters/ReportFilters";
import styles from './TicketsNumberReport.module.css'

const reportApiUrl = process.env.REACT_APP_SNOW_HOST+"/api/snowreports/GetRangedDate";

const TicketsNumberReport = () => {

    const [chartData, setChartData] = useState([]);
    const [chartLines, setChartLines] = useState([]);
    const [requestUrl, setRequestUrl] = useState("");

    const [loadingStatus, setLoadingStatus] = useState(false)
    const [loadedTime, setLoadedTime] = useState("")
    const [error, setError] = useState("")

    const setQueryString = (queryStringParameters) =>
    {
        setRequestUrl(reportApiUrl+queryStringParameters)
    }

    const exportData = async() =>
    {
        console.log("Get -> "+requestUrl);
        const urlSearchParams = new URLSearchParams(requestUrl);
        const params = Object.fromEntries(urlSearchParams.entries());
        for(let p in params)
        {
            if (urlSearchParams.get(p)=="")
            {
                return ;
            }
        }

        setLoadingStatus(true);
        setError("");

        //Measure time
        let startTime = new Date();

        setChartData([]);
        const response = await fetch(requestUrl).then((r)=>{
            if (!r.ok)
            {
                setError(r.statusText+" Error loading data for "+requestUrl);
            }
            return r;
        })

        if (response.ok)
        {
            setChartData(await response.json());

            //Measure time
            let endTime = new Date();
            let timeDiff = endTime - startTime;
            timeDiff /= 1000;
            setLoadedTime("Loaded for "+timeDiff+" seconds | "+requestUrl)
            //End measuring time
        }

        setLoadingStatus(false);
    }

    useEffect(()=>{
        exportData();
        }, [requestUrl])

    return(
        <ReportFiltersContext.Provider value={{chartData, chartLines, setChartLines, setQueryString}}>

            {loadingStatus==true?<div className="alert alert-primary">Loading...</div>: error.length>0 ? <div className="alert alert-danger">{error}</div> : <div className="alert alert-success">{loadedTime}</div>}

            <div className={styles.Report}>
                <ReportFilters />
                <TicketsNumberChart />
            </div>
        </ReportFiltersContext.Provider>
    );
};




export default TicketsNumberReport;