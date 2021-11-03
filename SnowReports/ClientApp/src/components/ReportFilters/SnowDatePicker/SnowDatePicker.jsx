import React, {useState} from 'react';
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css';
import styles from './SnowDatePicker.module.css'

const SnowDatePicker = ({SetDateRange, DateRange}) => {

    const [sDate, setStartDate] = useState(DateRange.startDate);
    const [eDate, setEndDate] = useState(DateRange.endDate);

    const onChange = dates => {
        const [start, end] = dates;

        if (start!=null && end!=null)
        {
            SetDateRange({startDate:start, endDate:end})
        }

        setStartDate(start);
        setEndDate(end);
    }

    let displayFormat = 'yyyy-MM-dd';
    return (
        <div>
            <DatePicker
                //id={startDateId}
                selected={sDate}
                selectsRange
                startDate={sDate}
                endDate={eDate}
                //placeholderText={placeholder}
                dateFormat={displayFormat}
                onChange={onChange}
                //locale={selectLocale(locale)}
                //customInput={<CustomInput />}
            />
        </div>
    );
};

export default SnowDatePicker;