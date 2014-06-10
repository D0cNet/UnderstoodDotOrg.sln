require.config({
    paths: {
        jqueryMouseWheel: "lib/ui/deps/CustomScrollbar/jquery.mousewheel.min",
        scrollPlugin: "lib/ui/deps/CustomScrollbar/jquery.mCustomScrollbar",
        scrollCSS: "lib/ui/deps/CustomScrollbar/jquery.mCustomScrollbar"
    },
    shim: {
        'scrollPlugin': { deps: ['jqueryMouseWheel'] },
        'jqueryMouseWheel': { deps: ['jqueryui'] }
    }
});

define("Scrollbar", ["sitecore", "jqueryMouseWheel", "scrollPlugin", "css!scrollCSS"], function (_sc) {
    _sc.Factories.createBehavior("Scrollbar", {
        beforeRender: function () {
            this.on("didRender", this.update, this);
        },
        update: function () {
            this.$el.mCustomScrollbar("update");
        },
        afterRender: function () {
            this.enableScroll();
        },
        enableScroll: function () {
            var scroll = this.$el.find(".totalScrollOffset");
            if (scroll.length === 0) {
                var insertTheScrollArea = '<div style="height:0px;" class="totalScrollOffset"></div>';
                this.$el.height(this.model.get("height"));
                this.$el.css({
                    position: "relative",
                    overflow: "auto"
                });
                this.$el.append(insertTheScrollArea);
                this.$el.mCustomScrollbar();
            }
        }
    });
});