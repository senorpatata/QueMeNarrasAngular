var abp = abp || {};
(function () {

    console.log("ABP MOMENT");

    if (!moment || !moment.tz) {
        console.log("No moment");
        return;
    }

    /* DEFAULTS *************************************************/

    abp.clock = abp.clock || {};
    abp.clock.provider = abp.clock.provider || {};
    abp.clock.provider.supportsMultipleTimezone = false;

    abp.timing = abp.timing || {};
    abp.timing.localClockProvider = abp.timing.localClockProvider || {};



    /* FUNCTIONS **************************************************/

    abp.timing.convertToUserTimezone = function (date) {
        var momentDate = moment(date);
        var targetDate = momentDate.clone().tz(abp.timing.timeZoneInfo.iana.timeZoneId);
        return targetDate;
    };

})();