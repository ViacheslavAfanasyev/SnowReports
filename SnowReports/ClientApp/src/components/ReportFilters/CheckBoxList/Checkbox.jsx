import React from 'react';
import styles from './Checkbox.module.css'
const Checkbox = ({CheckboxOnChange, ...props}) => {

    return (
        <div /*className={props.className}*/>
            <input id={`state-checkbox-${props.value}`} type="checkbox" className={props.inputClass}
                   value={props.value}
                   name={props.value}
                   checked={props.checked}
                   onChange={CheckboxOnChange}/>

            <label htmlFor={`state-checkbox-${props.value}`} className={`${props.labelClass} noselect dim`} >{props.value}</label>
        </div>
    );
};

export default Checkbox;