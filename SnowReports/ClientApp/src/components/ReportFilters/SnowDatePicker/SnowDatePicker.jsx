import React, {useState, useEffect} from 'react';
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css';
import styles from './SnowDatePicker.module.css'

const SnowDatePicker = ({setDate}) => {

    //Set initial values
    const weekAgo = new Date()
    weekAgo.setDate(weekAgo.getDate()-7)
    const [dateRange, SetDateRange] = useState({startDate:weekAgo, endDate : new Date()})

    useEffect(()=>{
        setDate({startDate:weekAgo, endDate : new Date()})
    },[])


    const onChange = dates => {
        const [start, end] = dates;
        SetDateRange({startDate:start, endDate:end})

        if (start!=null && end!=null)
        {
            setDate({startDate:start, endDate:end})
        }
    }

    let displayFormat = 'yyyy-MM-dd';
    return (
        <div>
            <DatePicker
                selected={dateRange.startDate}
                selectsRange
                startDate={dateRange.startDate}
                endDate={dateRange.endDate}
                dateFormat={displayFormat}
                onChange={onChange}
            />
        </div>
    );
};

export default SnowDatePicker;