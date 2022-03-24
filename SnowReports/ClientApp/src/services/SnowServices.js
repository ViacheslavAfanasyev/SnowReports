import axios from "axios";

const statesComparedReportUrl = process.env.REACT_APP_SNOW_HOST+"/api/snowreports/GetRangedDateForState";
const regionsComparedReportUrl = process.env.REACT_APP_SNOW_HOST+"/api/snowreports/GetRangedDateForRegions";


const assignmentGroupsUrl = process.env.REACT_APP_SNOW_HOST+'/api/snowreports/AccumulatedAssignmentGroups';
const regionsUrl = process.env.REACT_APP_SNOW_HOST+"/api/snowreports/Regions";
const ticketStatesUrl = process.env.REACT_APP_SNOW_HOST+'/api/SnowReports/States';
const ticketsLevelsUrl = process.env.REACT_APP_SNOW_HOST+'/api/SnowReports/TicketsLevels';

export default class SnowServices{

    static async GetStatesComparedReportData(queryString)
    {
        if (SnowServices.hasQueryStringEmptyParameters(queryString,"state") == false){
            console.log("GetStatesComparedReportData" + queryString)
            const response = await axios.get(statesComparedReportUrl+queryString)
            return response.data;
        }

        return '';
    }

    static async GetRegionsComparedReportData(queryString)
    {

        if (SnowServices.hasQueryStringEmptyParameters(queryString,"assigmentGroup") == false){
            console.log("GetRegionsComparedReportData" + queryString)
            const response = await axios.get(regionsComparedReportUrl+queryString)
            return response.data;
        }

        return '';
    }

    static async GetAssigmentGroups(addCheckedParameter=false)
    {
        return await SnowServices.GetData(assignmentGroupsUrl,addCheckedParameter)
    }
    static async GetRegions(addCheckedParameter=false)
    {
        return await SnowServices.GetData(regionsUrl,addCheckedParameter)
    }


    static async GetTicketStates(addCheckedParameter=false)
    {
        return await SnowServices.GetData(ticketStatesUrl, addCheckedParameter)
    }

    static async GetTicketsLevels(addCheckedParameter=false)
    {
        return await SnowServices.GetData(ticketsLevelsUrl,addCheckedParameter)
    }

    static async GetData(url, addCheckedParameter=false)
    {
        const response = await axios.get(url)
        //const result = [];
        //return Object.keys(response.data).forEach(key => result.push({key: key, value: response.data[key], label:response.data[key] }))

        if (addCheckedParameter==false)
        {
            return response.data;
        }
        else
        {
            return SnowServices.CreateCheckboxes(response.data);
        }
    }

    static CreateCheckboxes = (json) =>
    {
        const result = [];
        Object.keys(json).forEach(key => result.push({key: key, value: json[key], checked: false}))
        result[0].checked = true;
        return result;
    }

    static hasQueryStringEmptyParameters = (queryString, notVerifiedParam) =>
    {
        if (queryString==undefined || queryString=="")
        {
            return true;
        }
        const queryStringSearchParams = new URLSearchParams(queryString);
        const params = Object.fromEntries(queryStringSearchParams.entries());


        for(let p in params)
        {
            if (queryStringSearchParams.get(p)=="" && notVerifiedParam!=p || queryStringSearchParams.get(p) == "null")
            {
                return true;
            }
        }
        return false;
    }
}
