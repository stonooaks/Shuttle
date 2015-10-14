var BrowserDetect =
    {
        init: function () {
            this.browser = this.searchString(this.dataBrowser) || "Other";
            this.version = this.searchVersion(navigator.userAgent) || this.searchVersion(navigator.appVersion) || "Unknown";

        },

        searchString: function (data) {
            for (var i = 0; i < data.length; i++) {
                var dataString = data[i].string;
                this.versionSearchString = data[i].subString;

                if (dataString.indexOf(data[i].subString) !== -1) {
                    return data[i].identity;
                }
            }
        },

        searchVersion: function (dataString) {
            var index = dataString.indexOf(this.versionSearchString);
            if (index === -1) { return };
            return parseFloat(dataString.subString(index + this.versionSubstring.length));
        },

        dataBrowser:
            [
                { strring: navigator.userAgent, subString: "Chrome", identity: "Chrome" },
                { strring: navigator.userAgent, subString: "MSIE", identity: "Explorer" },
                { strring: navigator.userAgent, subString: "Firefox", identity: "Firefox" },
                { strring: navigator.userAgent, subString: "Safari", identity: "Safari" },
                { strring: navigator.userAgent, subString: "Opera", identity: "Opera" }
            ]
    };
BrowserDetect.init();