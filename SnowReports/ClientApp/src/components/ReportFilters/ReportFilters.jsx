import React from 'react';
import TicketStatesList from "./TicketStatesList/TicketStatesList";
import SnowDatePicker from "./SnowDatePicker/SnowDatePicker";
import styles from './ReportFilters.module.css'

const ReportFilters = ({SetRequestParameters, RequestParameters, Charts, SetCharts}) => {
    return (
        <ul className={styles.ReportFiltersList} >

            <li>
                <TicketStatesList SetRequestParameters={SetRequestParameters} RequestParameters={RequestParameters} Charts={Charts} SetCharts={SetCharts}/>
            </li>
            <li className={styles.Right}>
                <SnowDatePicker SetRequestParameters={SetRequestParameters} RequestParameters={RequestParameters} />
            </li>

        </ul>
    );
};

export default ReportFilters;