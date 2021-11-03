import React from 'react';



const AssignmentGroup = ({value, name}) => {

    return (
        <option value={value} >{name}</option>
    );
};

export default AssignmentGroup;