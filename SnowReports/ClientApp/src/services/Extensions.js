const aryIannaTimeZones = [

        'Europe/Kiev',
        'Pacific/Easter',
        'UTC',
    ];


export default class Extensions{

    static GetTimeZones()
    {
       let results = [];
        aryIannaTimeZones.forEach((timeZone) => {

            const offset = parseInt(Extensions.getTimezoneOffset(timeZone));
            const name = timeZone+" "+(offset>0?"+":"")+offset;
            results.push({name:name, value: offset})
        });

        return results;
    }

    static getTimezoneOffset(timeZone) {
                const now = new Date();
                const tzString = now.toLocaleString('en-US', { timeZone });
                const localString = now.toLocaleString('en-US');
                const diff = (Date.parse(localString) - Date.parse(tzString)) / 3600000;
                const offset = diff + now.getTimezoneOffset() / 60;

                return -offset;
        }

}