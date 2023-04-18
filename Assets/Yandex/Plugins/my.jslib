mergeInto(LibraryManager.library, {

    Hello: function () {
        window.alert("Hello world")
        console.Log("sdfsdfs");
    },

    ShowAdv: function () {
        ysdk.adv.showFullscreenAdv({
            callbacks: {
                onClose: function (wasShown) {
                    console.log("------------------CLOSED------------------")
                    // some action after close
                },
                onError: function (error) {
                    // some action on error
                }
            }
        })
    },

    SaveExtern: function (date) {
        var dateString = UTF8ToString(date);
        var myobj = JSON.parse(dateString);
        player.setData(myobj);
    },

    LoadExtern: function () {
        player.getData().then(_date => {
            const myJSON = JSON.stringify(_date);
            myGameInstance.SendMessage('ScoreScript', 'SetPlayerInfo', myJSON);
        });
    },


    SetToLeaderboard: function (value) {
        ysdk.getLeaderboards()
            .then(lb => {
                // Без extraData
                lb.setLeaderboardScore('Score', value);
            });
    },


  GetLang: function () {
    var lang = ysdk.environment.i18n.lang;
    var bufferSize = lengthBytesUTF8(lang) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(lang, buffer, bufferSize);
    return buffer;
    },
});