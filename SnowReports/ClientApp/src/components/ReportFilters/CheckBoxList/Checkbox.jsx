import React from 'react';

const Checkbox = ({CheckboxOnChange, ...props}) => {

    return (
        <div className={props.className}>
            <input id={`state-checkbox-${props.value}`} type="checkbox"
                   value={props.value}
                   name={props.value}
                   checked={props.checked}
                   onChange={CheckboxOnChange}/>

            <label htmlFor={`state-checkbox-${props.value}`} className='noselect'>{props.value}</label>
        </div>
    );
};

export default Checkbox;