import React, {useState} from 'react';

const StateCheckbox = ({CheckboxOnChange,...props}) => {

    //const [checked, setChecked] = useState(props.checked);
    //function CheckboxOnChange(e)
    //{
        //setChecked(e.target.checked);
    //}

    return (
        <div>
            <input id={`state-checkbox-${props.value}`} type="checkbox"
                    value={props.value}
                    name={props.label}
                    checked={props.checked}
                    onChange={CheckboxOnChange}/>

            <label for={`state-checkbox-${props.value}`} className='noselect' >{props.label}</label>



        </div>
    );
};

export default StateCheckbox;