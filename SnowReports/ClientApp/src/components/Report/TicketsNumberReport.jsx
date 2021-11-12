import React, {useState, useEffect } from 'react';
import {ReportFiltersContext} from '../../context/ReportFiltersContext'
import TicketsNumberChart from "./TicketsNumberChart";
import ReportFilters from "../ReportFilters/ReportFilters";
import styles from './TicketsNumberReport.module.css'
import {useFetching} from "../../hooks/useFetch";
import SnowServices from "../../services/SnowServices";

const TicketsNumberReport = () => {

    const [chartData, setChartData] = useState([]);
    const [chartLines, setChartLines] = useState([]);
    const [queryString, setQueryString] = useState("");

    const [fetchData,isLoading,error] = useFetching(async () => {
        const data = await SnowServices.GetTicketsReportData(queryString);
        setChartData(data);
    })

    useEffect(fetchData, [queryString])

    return(
        <ReportFiltersContext.Provider value={{chartData, chartLines, setChartLines, setQueryString}}>

            {error!=''?<div className="alert alert-danger">{error}</div>:<div></div>}
            {isLoading?<div className="alert alert-primary">Loading...</div>:<div className="alert alert-success">Loaded</div>}

            <div className={styles.Report}>
                <ReportFilters />
                <TicketsNumberChart />
            </div>
        </ReportFiltersContext.Provider>
    );
};




export default TicketsNumberReport;