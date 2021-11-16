import React, { useState, useEffect } from "react";
import Checkbox from "./Checkbox";
import styles from './CheckboxesList.module.css'

const CheckboxesList = ({setSelectedValue, setAllowCombineCheckboxes, source, name}) => {

    const storageName = name+"_checkboxesList";
    const storageV = localStorage.getItem(storageName);
    let selectedCheckboxes = [];
    if (storageV!=undefined)
    {
        selectedCheckboxes = storageV.split(',');
    }

    const [combinedCheckboxState, setCombinedCheckboxState] = useState(false)

    useEffect(()=>{
        if (source!=undefined && source.length>0 && selectedCheckboxes.length>0)
        {
            let shallowArr = [...source];
            shallowArr.forEach((v,i)=>{
                shallowArr[i].checked = selectedCheckboxes[i].toLowerCase() == "true"
            })
            setSelectedValue(shallowArr);
        }
    },[source.length])


    if (source==null || source == undefined)
    {
        console.log("CheckboxesList component | source variable is null or undefined");
        return <div></div>
    }

    if (!Array.isArray(source))
    {
        console.log("CheckboxesList component | source is not an array");
        return  <div></div>
    }

    function OnChange(e)
    {

    }

        return (
            <div>
               <Checkbox CheckboxOnChange={(e)=>{setAllowCombineCheckboxes(e.target.checked); setCombinedCheckboxState(e.target.checked);}} value="Combine" checked={combinedCheckboxState} className={styles.CombineSwitcher}  />

        <ul id={name} className={styles.CheckboxesList} >
            {source.map((elem, index) => <li key={index}><Checkbox CheckboxOnChange={(e)=>
            {let shallowArr = [...source]; shallowArr[elem.key].checked = e.target.checked;

            let storageValue = [];
            shallowArr.map((v,i)=>storageValue.push(v.checked));
            localStorage.setItem(storageName, storageValue);

            setSelectedValue(shallowArr);
          }}
            key={elem.key} value={elem.value} label={elem.value}
            checked={elem.checked} /></li>)}
        </ul>
    </div>
    );
};


export default CheckboxesList;