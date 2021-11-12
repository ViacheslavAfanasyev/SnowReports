import React, {useState, useEffect} from 'react';
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css';
import styles from './SnowDatePicker.module.css'

const SnowDatePicker = ({setDate}) => {

    const savedDateRange = localStorage.getItem("dateRange")
    let [deafultStart, defaultEnd] = [];

    if (savedDateRange==undefined)
    {
        //Set initial values
        deafultStart = new Date()
        defaultEnd = new Date()
        deafultStart.setDate(deafultStart.getDate()-7)
    }
    else
    {
        const [from, to] = savedDateRange.split(',');
        deafultStart = new Date(from);
        defaultEnd = new Date(to);
    }

    const [dateRange, SetDateRange] = useState({startDate:deafultStart, endDate : defaultEnd})

    useEffect(()=>{
        setDate({startDate:deafultStart, endDate : defaultEnd})
    },[])




    const onChange = dates => {
        const [start, end] = dates;
        SetDateRange({startDate:start, endDate:end})

        if (start!=null && end!=null)
        {

            setDate({startDate:start, endDate:end})
            localStorage.setItem("dateRange",dates);
        }
    }



    let displayFormat = 'yyyy-MM-dd';
    return (
        <div>
            <DatePicker
                closeOnScroll={true}
                selected={dateRange.startDate}
                selectsRange
                startDate={dateRange.startDate}
                endDate={dateRange.endDate}
                dateFormat={displayFormat}
                onChange={onChange}
                maxDate={new Date()}
                //withPortal
            />
        </div>
    );
};

export default SnowDatePicker;