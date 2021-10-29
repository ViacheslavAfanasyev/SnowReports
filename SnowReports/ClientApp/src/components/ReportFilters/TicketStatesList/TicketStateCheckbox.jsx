import React from 'react';

const TicketStateCheckbox = ({CheckboxOnChange, ...props}) => {

    return (
        <div>
            <input id={`state-checkbox-${props.value}`} type="checkbox"
                   value={props.value}
                   name={props.label}
                   checked={props.checked}
                   onChange={CheckboxOnChange}/>

            <label for={`state-checkbox-${props.value}`} className='noselect'>{props.label.replace("_", " ")}</label>


        </div>
    );
};

export default TicketStateCheckbox;