import React from 'react';
import TicketStatesList from "./TicketStatesList/TicketStatesList";
import SnowDatePicker from "./SnowDatePicker/SnowDatePicker";
import styles from './ReportFilters.module.css'
import AssignmentGroupsDropDown from "./AssignmentGroup/AssignmentGroupsDropDown";

const ReportFilters = ({SetDateRange, SetAssignmentGroup,DateRange, Charts, SetCharts}) => {
    return (
        <ul className={styles.ReportFiltersList} >

            <li>
                <TicketStatesList Charts={Charts} SetCharts={SetCharts}/>
            </li>
            <li>
                <AssignmentGroupsDropDown SetAssignmentGroup={SetAssignmentGroup} />
            </li>
            <li className={styles.Right}>
                <SnowDatePicker SetDateRange={SetDateRange} DateRange={DateRange} />
            </li>

        </ul>
    );
};

export default ReportFilters;