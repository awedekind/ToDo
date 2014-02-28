var ServiceApi = (function () {
    var lowercaseKeys = function (data) {
        data = JSON.stringify(data);
        return regexReplace(data, /"\w*":/g, function ($0) {
            return $0.toLowerCase();
        });
    };

    var regexReplace = function (data, regex, replacer) {
        return JSON.parse(data.replace(regex, replacer));
    };

    var load = function (callback, url) {
        $.ajax({
            url: url,
            success: function (data) {
                callback(lowercaseKeys(data));
            }
        });
    };

    var loadMany = function (id, url, callback) {
        var json = { id: id };
        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(json),
            success: function(data) {
                callback(lowercaseKeys(data));
            }
        });
    };

    var modify = function (item, url, callback) {
        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(item),
            success: function (data) {
                callback(data);
            }
        });
    };

    var remove = function (id, url, callback) {
        var json = { id: id };
        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(json),
            success: function (data) {
                callback(data);
            }
        });
    };

    return {
        load: load,
        modify: modify,
        remove: remove,
        loadMany: loadMany
    };
}());
