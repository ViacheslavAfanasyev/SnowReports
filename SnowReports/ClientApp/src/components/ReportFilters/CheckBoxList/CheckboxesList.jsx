import React, { useState, useEffect } from "react";
import Checkbox from "./Checkbox";
import styles from './CheckboxesList.module.css'


function ApplyStyles()
{
    const cs = document.querySelector("."+styles.CombinedSwitcher);
    const cl = document.querySelector("."+styles.CombinedLabel);

    if (cs.checked)
    {
        const elems = document.getElementsByClassName(styles.regularLabel);
        for(let i=0; i<elems.length; ++i){
            elems[i].classList.add(styles.dim);
        }

        cl.classList.remove(styles.dim);
    }
    else {
        const elems = document.getElementsByClassName(styles.regularLabel);
        for(let i=0; i<elems.length; ++i){
            elems[i].classList.remove(styles.dim);
        }
        cl.classList.add(styles.dim);
    }
}

const CheckboxesList = ({setSelectedValue, setAllowCombineCheckboxes, source, valuePropName, labelPropName, name}) => {

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

    return (
            <div>

        <Checkbox CheckboxOnChange={(e)=>{setAllowCombineCheckboxes(e.target.checked); setCombinedCheckboxState(e.target.checked); ApplyStyles();}}
                         value="Combine" checked={combinedCheckboxState}
                       labelClass={styles.CombinedLabel}
                       inputClass={styles.CombinedSwitcher}  />

        <ul id={name} className={styles.CheckboxesList} >
            {source.map((elem, index) => <li key={index}><Checkbox CheckboxOnChange={(e)=>
            {
                let shallowArr = [...source];
                shallowArr[elem.key].checked = e.target.checked;

            let storageValue = [];
            shallowArr.map((v,i)=>storageValue.push(v.checked));
            localStorage.setItem(storageName, storageValue);

            setSelectedValue(shallowArr);
          }}
            key={elem.key} value={elem[valuePropName]} label={elem[labelPropName]}
/*            key={elem.key} value={elem.value} label={elem.value}*/
            checked={elem.checked}
            labelClass={styles.regularLabel}
            inputClass={styles.regularCheckbox}

            /></li>)}
        </ul>
    </div>
    );
};


export default CheckboxesList;