import React, {useState} from 'react';
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css';
import styles from './SnowDatePicker.module.css'

const SnowDatePicker = ({SetRequestParameters, RequestParameters}) => {

    const [sDate, setStartDate] = useState(new Date());
    const [eDate, setEndDate] = useState(new Date());

    const onChange = dates => {
        const [start, end] = dates;

        if (start!=null && end!=null)
        {

            SetRequestParameters(prev => {
                return{
                    ...RequestParameters, startDate: start.toJSON().slice(0,10), endDate:end.toJSON().slice(0,10)
                }
            })
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