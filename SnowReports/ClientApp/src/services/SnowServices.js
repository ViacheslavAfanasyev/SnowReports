import axios from "axios";

const ticketsReportData = process.env.REACT_APP_SNOW_HOST+"/api/snowreports/GetRangedDate";
const assignmentGroupsUrl = process.env.REACT_APP_SNOW_HOST+'/api/snowreports/AccumulatedAssignmentGroups';
const ticketStatesUrl = process.env.REACT_APP_SNOW_HOST+'/api/SnowReports/States';
const ticketsLevelsUrl = process.env.REACT_APP_SNOW_HOST+'/api/SnowReports/TicketsLevels';

export default class SnowServices{

    static async GetTicketsReportData(queryString)
    {

        if (SnowServices.hasQueryStringEmptyParameters(queryString) == false){
            const response = await axios.get(ticketsReportData+queryString)
            return response.data;
        }

        return '';
    }

    static async GetAssigmentGroups(addCheckedParameter=false)
    {
        return await SnowServices.GetData(assignmentGroupsUrl,addCheckedParameter)
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

    static hasQueryStringEmptyParameters = (queryString) =>
    {
        if (queryString==undefined || queryString=="")
        {
            return true;
        }
        const queryStringSearchParams = new URLSearchParams(queryString);
        const params = Object.fromEntries(queryStringSearchParams.entries());

        for(let p in params)
        {
            if (queryStringSearchParams.get(p)=="")
            {
                return true;
            }
        }
        return false;
    }
}
