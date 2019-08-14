var app = new Vue({
    el: '#view',
    data: {
        index:0,
        vocabularyList: ' '
        
    },
    methods: {
        next: function () {

        },
        back: function () {

        }
    },
    computed: {
        showWord: function () {
            return this.vocabularyList[this.index];
        },
        showChinese: function () {
            return this.vocabularyList[this.index];
        }
    }
});

init();

function init() {
    app.vocabularyList = viewSource;
    
}
