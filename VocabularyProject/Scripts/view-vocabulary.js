var app = new Vue({
    el: '#view',
    data: {
        index:0,
        vocabularyList: ' ',
        soundList:''
        
    },
    methods: {
        next: function () {
            console.log("next is click");
            if (this.index < this.vocabularyList.length - 1) {
                this.index = this.index + 1;
                this.sound(this.index);
            }
        },
        back: function () {
            console.log("back is click");
            if (this.index > 0) {
                this.index = this.index - 1;
                this.sound(this.index);
            }
                
        },
        sound: function (i) {
            console.log("use sound function")
            if ('sound' in this.vocabularyList[i]) {
                this.vocabularyList[i].sound.play();
            }
            else {
                var audio = new Audio();
                audio.src = 'https://translate.google.com/translate_tts?ie=utf-8&tl=en&client=tw-ob&q=' + encodeURI(this.vocabularyList[i].word.trim());
                audio.play();
                this.vocabularyList[i].sound = audio;
            }
        }
    },
    computed: {
        showWord: function () {
            return this.vocabularyList[this.index].word;
        },
        showPart: function () {
            return this.vocabularyList[this.index].part;
        },
        showChinese: function () {
            return this.vocabularyList[this.index].chinese;
        }
    }
});


//function aa() {
//     viewSource = @Html.Action("List", new { unitID = 1 });
//    $.ajax({
//        type: 'POST',
//        url: @Url.Action("List"),
//    data: 'unitID='@ViewBag.UnitList ,
//    dataType: "JSON",
//        error: function () { console.log('連線異常') },
//    success: function (returnData) {
//        var viewReturn = returnData;
//        console.log(viewReturn);

//    }
//});
//}

function init(unitList,sourceLink) {
    //app.vocabularyList = viewSource;
        $.ajax({
            type: 'POST',
            url: sourceLink,
            data: unitList,
            dataType: "JSON",
            error: function () { console.log('連線異常') },
            success: function (returnData) {
                app.vocabularyList = returnData;
                app.soundList = returnData;
                console.log(returnData);
                console.log(app.vocabularyList.length);
            }
        });
    
}
