import React from 'react';

const DropDownElement = ({value}) => {

    return (
        (value.value!=undefined && value.name!=undefined)
            ? <option value={value.value} >{value.name}</option>
            : <option value={value} >{value}</option>
    );
};

export default DropDownElement;