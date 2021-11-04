import React, {useEffect, useState} from 'react';
import TicketStatesList from "./TicketStatesList/TicketStatesList";
import SnowDatePicker from "./SnowDatePicker/SnowDatePicker";
import styles from './ReportFilters.module.css'
import DropDownFilter from "./DropDownFilter/DropDownFilter";


const assignmentGroupsUrl = process.env.REACT_APP_SNOW_HOST+'/api/snowreports/AccumulatedAssignmentGroups';

const ReportFilters = ({SetDateRange, DateRange, Charts, SetCharts}) => {

    const [assignmentGroup, setAssignmentGroup] = useState("")
    const [assignmentGroupsList, setAssignmentGroupsList] = useState([])

    useEffect(async()=> {
        const response = await fetch(assignmentGroupsUrl);
        const assignmentGroupsList = await response.json();
        setAssignmentGroupsList(assignmentGroupsList);
        setAssignmentGroup(assignmentGroupsList[0]);
    },[]);

    return (
        <ul className={styles.ReportFiltersList} >

            <li>
                <TicketStatesList Charts={Charts} SetCharts={SetCharts}/>
            </li>
            <li>
                <DropDownFilter setSelectedValue={setAssignmentGroup} source={assignmentGroupsList} name={"AssigmentGroups"} />
            </li>
            <li className={styles.Right}>
                <SnowDatePicker SetDateRange={SetDateRange} DateRange={DateRange} />
            </li>

        </ul>
    );
};

export default ReportFilters;