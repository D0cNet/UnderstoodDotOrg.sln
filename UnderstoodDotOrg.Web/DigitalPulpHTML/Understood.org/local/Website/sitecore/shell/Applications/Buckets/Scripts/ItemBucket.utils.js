/*********** Global Variables ***********/

var continueSearchViewType = 'ContinueSearch';
var dialogViewType = 'Dialog';
var dataSourceViewType = 'DataSource';
var rteViewType = 'Rte';
var mediaViewType = 'Media';
var fieldViewType = 'Field';
var indexName;
var DefaultPageSize = 20;
/*****************************************/


function BindItemResult(b) {
    if (window.currentBucketsViewType == window.dataSourceViewType) {
        $j('#ItemLink', parent.document.body).val(b);
    } else if (window.currentBucketsViewType == window.mediaViewType) {
        b = b.replace(window.imageFullPath, "");
        $j('#Filename', parent.document.body).val(b);
        $j('#ItemName', parent.document.body).val(b);
    } else if (window.workBox != "") {
        window.scForm.getParentForm().postRequest('', '', '', 'search:launchresult(url=' + b + ')');
    } else {
        $j('#ItemLink', parent.document.body).val(b);
        jQuery.ajax({
            type: "POST",
            url: "/sitecore/shell/Applications/Buckets/ItemBucket.asmx/GetMediaPath",
            data: "{'id' : '" + b + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (a) {


                var parsedValue = a.d.replace('/sitecore/system/Marketing Center/Test Lab', '').replace('/sitecore/templates', '');

                $j('#TemplateName', parent.document.body).val(a.d);
                $j('#Filename', parent.document.body).val(parsedValue);
                $j('#IconFile', parent.document.body).val(a.d);

                var parsedId = b.replace(/{/g, "").replace(/}/g, "").replace(/-/g, "");
                if ($j('#TemplateLister_Selected', parent.document.body).length > 0) {
                    $j('#TemplateLister_Selected', parent.document.body)[0].value = parsedId;

                }
                if ($j('#Treeview_Selected', parent.document.body).length > 0) {
                    $j('#Treeview_Selected', parent.document.body)[0].value = parsedId;
                }

                var numRand = Math.floor(Math.random() * 101);
                $j('#TreeList_selected', parent.document.body).html($j('#TreeList_selected', parent.document.body).html() + "<option id=\"I" + numRand + "\" value=\"I" + numRand + "|" + b + "\">" + a.d + "</option>");
            }
        });
    }
}

var text = "";
var FieldNameToPassThrough = "";
var div = "";


function scGetFrameValue(value, request) {
    if (request.parameters == "contenteditor:save" || request.parameters == "item:save") {
        var b = $j('#EditorFrames iframe[sc_value]', window.parent.document).attr('sc_value');
        parent.scForm.modified = true;
        $j('#EditorFrames iframe[sc_value]', window.parent.document).attr('sc_value', b);
    }
}

if (window.currentBucketsViewType == window.fieldViewType) {
    jQuery.ajax({
        type: "POST",
        url: "/sitecore/shell/Applications/Buckets/ItemBucket.asmx/GetFieldValues",
        data: "{'FieldName' : '" + text + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: fillSavedIds
    });
}

$j(".removeid").live("click", function () {
    if ($j(this)[0].previousElementSibling == undefined) {
        var returnId = $j(this)[0].parentElement.innerText;
        returnId = returnId.substring(0, returnId.length - 1);
    } else {
        returnId = $j(this)[0].previousElementSibling.innerHTML;
    }

    FieldNameToPassThrough = frameElement.parentElement.previousSibling.outerHTML;
    div = document.createElement("div");
    div.innerHTML = FieldNameToPassThrough;
    text = jQuery.browser.msie ? div.innerText.replace(":", "") : div.textContent.replace(":", "");

    jQuery.ajax({
        type: "POST",
        url: "/sitecore/shell/Applications/Buckets/ItemBucket.asmx/RemoveFieldValues",
        data: "{'newId' : '" + returnId + "', 'FieldName' : '" + text + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: fillSavedIds
    });

    $j(this).parents("li:first").remove();

});

function saveFieldValue(id) {
    FieldNameToPassThrough = frameElement.parentElement.previousSibling.outerHTML;
    div = document.createElement("div");
    div.innerHTML = FieldNameToPassThrough;
    text = jQuery.browser.msie ? div.innerText.replace(":", "") : div.textContent.replace(":", "");

    jQuery.ajax({
        type: "POST",
        url: "/sitecore/shell/Applications/Buckets/ItemBucket.asmx/SaveFieldValues",
        data: "{'newId' : '" + id + "', 'FieldName' : '" + text + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: fillSavedIds
    });
}

function fillSavedIds(data) {
    var searchList = data.d.toString().split('|');
    var outPut = "<ul>";
    for (var i = 0; i < searchList.length; i++) {
        outPut = outPut + '<li class="token-input-token-facebook"><span title="' + changeSearchLogic + '" style="background: url(\'images/id.gif\') no-repeat center center;padding: 0px 11px;"></span><span style="text-overflow: ellipsis;color:black;max-width: 411px;overflow: hidden; vertical-align:top;" class="id">' + searchList[i] + '</span><p class="id">' + searchList[i + 1] + '</p><span class="token-input-delete-token-facebook removeid" title="' + removeSearchTerm + '">×</span></li>';
        i++;
    }

    outPut = outPut + "</ul>";
    $j("#savedIds").html(outPut);
}

function GetItemPathFromMediaLibrary(id) {
    jQuery.ajax({
        type: "POST",
        url: "/sitecore/shell/Applications/Buckets/ItemBucket.asmx/GetMediaPath",
        data: "{'id' : '" + id + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (a) {
            return a.d;
        }
    });
}

function BindItemResultDatasource() {
    var query = buildQuery();
    query = query.concat(OnlyFacets).filter(function (element) { return !!element; });
    var result = "";
    $j.each(query, function () {
        var boolOperation = "";
        if (this.operation == "must") {
            boolOperation = "+";
        } else if (this.operation == "not") {
            boolOperation = "-";
        }

        result += boolOperation + this.type + ":" + this.value + "&";
    });

    if (query.length > 0) {
        result = result.slice(0, -1);
    }

    $j('#ItemLink', parent.document.body).val(result || window.filterForSearch);
}

function RetrieveScalabilitySettings() {
    jQuery.ajax({
        type: "POST",
        url: "/sitecore/shell/Applications/Buckets/ItemBucket.asmx/QueryServer",
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (a) {
            window.QueryServer = a.d;
        }
    });
}

function GetAllSearchFilters() {
    jQuery.ajax({
        type: "POST",
        url: "/sitecore/shell/Applications/Buckets/ItemBucket.asmx/GetAllSearchFilters",
        data: "",
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (a) {
            window.AllFilters = a.d;
            return a.d;
        }
    });
}

function GetDefaultView() {
    jQuery.ajax({
        type: "POST",
        url: "/sitecore/shell/Applications/Buckets/ItemBucket.asmx/GetDefault",
        data: "",
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (a) {
            window.CurrentView = a.d;
        }
    });
}

function GetCurrentCulture() {
    jQuery.ajax({
        type: "POST",
        url: "/sitecore/shell/Applications/Buckets/ItemBucket.asmx/GetCalendarCulture",
        data: "",
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (a) {
            window.CurrentCulture = a.d;
        }
    });
}

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.search);
    if (results == null)
        return "";
    else
        return decodeURIComponent(results[1].replace(/\+/g, " "));
}

function runQuery(o, pageNumber, onSuccessFunction, onErrorFunction, pageSize) {

    if (pageSize == null || pageSize == 'undefined') {
        pageSize = DefaultPageSize;
    }

    var internalIndexName = indexName != undefined ? indexName : "";
    var parameters = {
        q: __scCleanupProperties(o.concat(addFilterGlobal())),
        pageNumber: pageNumber,
        type: "Query",
        pageSize: pageSize,
        version: "1",
        id: getParameterByName("id"),
        indexName: internalIndexName
    };

    __includeAdditionalParameters(parameters);

    $j.ajax({
        type: "GET",
        url: QueryServer + "/sitecore/shell/Applications/Buckets/Services/Search.ashx?callback=?",
        contentType: "application/json; charset=utf-8",
        dataType: "jsonp",
        cache: false,
        data: parameters,
        responseType: "json",
        success: onSuccessFunction,
        error: onErrorFunction
    });
    if (window.currentBucketsViewType == window.dataSourceViewType) {
        BindItemResultDatasource();
    }
}

function runFacet(o, pageNumber, onSuccessFunction, onErrorFunction, pageSize) {

    var internalIndexName = indexName != undefined ? indexName : "";

    if (pageSize == null || pageSize == 'undefined') {
        pageSize = DefaultPageSize;
    }

    var parameters = {
        q: __scCleanupProperties(o.concat(addFilterGlobal())),
        pageNumber: pageNumber,
        type: "facet",
        pageSize: pageSize,
        version: "1",
        id: getParameterByName("id"),
        indexName: internalIndexName
    };

    __includeAdditionalParameters(parameters);

    $j.ajax({
        type: "GET",
        url: QueryServer + "/sitecore/shell/Applications/Buckets/Services/Search.ashx?callback=?",
        contentType: "application/json; charset=utf-8",
        dataType: "jsonp",
        cache: false,
        data: parameters,
        responseType: "json",
        success: onSuccessFunction,
        error: onErrorFunction
    });
}

function Meta(a) {
    return a.IsClone ? "opacity:0.4;" : '';
}

function getGlobalQueryVariable(variable, qs) {
    if (qs != undefined) {
        var vars = qs.split("&");
        for (var i = 0; i < vars.length; i++) {

            var pair = vars[i].split(":");
            var cleanrType = pair[0].replace('+', '');
            cleanrType = cleanrType.replace('-', '');

            if (cleanrType == variable) {
                return unescape(pair[1]);
            }
        }
    }

    return "";
}

function extractFilterType(filter) {
    if (!filter) {
        return "";
    }

    var pair = filter.split(":");
    return pair[0].replace('+', '').replace('-', '');
}

function extractFilterOperation(filter) {
    if (!filter) {
        return "must";
    }

    var pair = filter.split(":");
    var charOperation = pair[0].charAt(0);

    if (charOperation == '+') {
        return "must";
    } else if (charOperation == '-') {
        return "not";
    }

    return "should";
}

function extractFilterValue(filter) {
    if (!filter) {
        return "";
    }

    var pair = filter.split(":");
    if (pair.length > 0) {
        return pair[1];
    }

    return "";
}

function getGlobalQueryVariableArray(variable, qs) {
    if (qs != undefined) {

        var vars = qs.split("&");
        var resultArray = new Array();

        for (var i = 0; i < vars.length; i++) {
            var filterType = extractFilterType(vars[i]);

            if (filterType == variable) {
                var value = extractFilterValue(vars[i]);
                if (value && value.length > 0) {
                    var boolOperation = extractFilterOperation(vars[i]);

                    resultArray.push({
                        type: filterType,
                        value: unescape(value),
                        operation: boolOperation,
                        friendlyName: unescape(value)
                    });
                }
            }
        }

        return resultArray;
    }

    return "";
}

function getGlobalQueryVariableBooleanOperation(variable, qs) {
    var variableEntries = getGlobalQueryVariableArray(variable, qs);
    var result = "must";
    if (variableEntries && variableEntries.length > 0) {
        var entry = variableEntries[0];
        if (entry) {
            var boolOperation = entry.operation;
            if (boolOperation && boolOperation.length > 0) {
                result = boolOperation;
            }
        }
    }

    return result;
}

function getBooleanOperationFromUI(objectUI) {
    var operation = 'must';
    if (objectUI) {
        var siblings = objectUI.siblings(".booleanOperation");
        if (siblings.hasClass("should")) {
            operation = 'should';
        } else if (siblings.hasClass("not")) {
            operation = 'not';
        } else if (siblings.hasClass("must")) {
            operation = 'must';
        }
    }

    // note: there might be an issue with default operation. Right now if we don't have any class (must/not/should) 
    // it is resolved as a "must" but visually it looks like "should". It is a bit confusing.
    return operation;
}

function getSortDirectionFromUI(objectUI) {
    var direction = 'asc';
    if (objectUI != null) {
        direction = (objectUI.prev().prev() && objectUI.prev().prev().attr('class')) ? objectUI.prev().prev().attr('class').replace('sortDirection should ', '').replace('sortDirection must ', '') : 'asc';
    }
    return direction;
}

function upperFirstLetter(str) {
    var string = str;
    string = string.toLowerCase().replace(/\b[a-z]/g, function (letter) {
        return letter.toUpperCase();
    });
    return string;
}

function resolveKnownDates(dateToParse) {
    var today = Date.today();
    switch (dateToParse) {
        case "Today": //TODO: Language Issue
            return today.toString("MM/dd/yyyy");
        case "Yesterday": //TODO: Language Issue
            return today.add(-1).days().toString("MM/dd/yyyy");
        case "LastWeek": //TODO: Language Issue
            return today.add(-7).days().toString("MM/dd/yyyy");
        case "LastMonth": //TODO: Language Issue
            return today.add(-1).months().toString("MM/dd/yyyy");
        case "LastYear": //TODO: Language Issue
            return today.add(-1).years().toString("MM/dd/yyyy");
        default:
            return dateToParse;
    }
}

function urlExists(testUrl) {
    var http = jQuery.ajax({
        type: "HEAD",
        url: testUrl,
        async: false
    });
    return http.status != 404;
}

function getFilterImageIconPath(filterName, boolOperation) {
    var imagePath = 'images/' + filterName + boolOperation + '.png';
    if (!urlExists(imagePath)) {
        imagePath = 'images/text' + boolOperation + '.png';
    }

    return imagePath;
}

//This will fetch all the available filters and will handle solving them.

function retrieveFilters() {
    var a = $j("#ui_element");
    var filterArray = new Array();
    $j.each(AllFilters, function () {
        filterArray.push(this.DisplayName);
    });

    var inAliases = false;
    var tmpStr = '<li class="token-input-token-facebook" title="{0}"><span  title="' + changeSearchLogic + '" style="background: url(\'images/{1}.png\') no-repeat center center;padding: 0px 11px;" class="{2} should"></span><span>{5}:</span><span style="text-overflow: ellipsis; white-space:nowrap;max-width: 150px; color:black; display: inline-block;overflow: hidden; vertical-align:top;" class="{3}">{4}</span><span class="token-input-delete-token-facebook remove" title="' + removeSearchTerm + '">×</span></li>';
    var inputField = a.find(".addition");
    $j.each(filterArray, function (index, filter) {
        if (inputField.val().toLowerCase().indexOf(filter + ":") == 0) {
            var searchValue = scHtmlEscape(inputField.val().split(":")[1]);
            inputField.val("");

            var ieMaxWidth = $j.browser.msie && filter.length + searchValue.length > 48 ? " tokenMaxWidth" : "";
            switch (filter) {
                case "start":
                case "end":
                    var str = tmpStr.scFormat(searchValue, filter, 'booleanOperation', filter + 'hidden' + ieMaxWidth, searchValue, filter);
                    break;
                case "sort":
                    str = tmpStr.scFormat(searchValue, filter, 'sortDirection', filter + ieMaxWidth, searchValue, filter);
                    break;
                case "text":
                    str = tmpStr.scFormat(searchValue, filter, 'booleanOperation', filter + ieMaxWidth, searchValue, filter);
                    break;
                case "tag":
                    str = tmpStr.scFormat(searchValue, filter, 'booleanOperation', filter + ieMaxWidth, searchValue.split('|')[0], filter);
                    break;
                case "template":
                    str = tmpStr.scFormat(searchValue, filter, 'booleanOperation', filter + ieMaxWidth, searchValue.split('|')[0], filter);
                    break;
                default:
                    var image = urlExists('images/' + filter + '.png') ? filter : 'text';
                    str = tmpStr.scFormat(searchValue, image, 'booleanOperation', filter + ieMaxWidth, searchValue, filter);
            }

            a.find(".boxme").prepend(str);
            scFixIeLayout();
            inAliases = true;
            return false;
        }
    });

    if (!inAliases) {
        var filter = inputField.val().split(":")[0];
        if (filter.length > 0) {
            if (inputField.val().indexOf(':') > -1) {
                var p = scHtmlEscape(inputField.val().split(":")[1]);
                inputField.val("");
                a.find(".boxme").prepend(tmpStr.scFormat(p, 'custom', 'booleanOperation', 'custom', p, filter));
                scFixIeLayout();
            }
        }
    }
}

function buildQuery() {
    var a = $j("#ui_element");
    var findArray = new Array();
    $j.each(AllFilters, function () {
        if (this.ClientSideHook == "normal" || this.ClientSideHook == "custom") { //TODO: Language Issue
            findArray.push(this.DisplayName);
        }
    });

    var n = new Array;
    $j.each(findArray, function (index, filter) {
        var b = a.find(".boxme li ." + filter);
        $j.each(b, function () {

            if (filter == "custom") { //TODO: Language Issue

                var value = $j(this).text();
                if (filter.replace("hidden", "") == "custom") {

                    value = $j(this).text();
                }

                if (value.indexOf("|") == -1) {
                    value = $j(this).prev().text().replace(":", "") + "|" + value;
                }

                n.push({
                    type: filter.replace("hidden", ""),
                    value: value,
                    operation: getBooleanOperationFromUI($j(this))
                });
            }
            else {

                n.push({
                    type: filter.replace("hidden", ""),
                    value: $j(this).text(),
                    operation: getBooleanOperationFromUI($j(this))
                });
            }
        });
    });

    //TODO: Hardcoded Logic
    var customSort = a.find(".boxme li .sort");
    var recent = a.find(".boxme li .recent");
    var starthidden = a.find(".boxme li .starthidden");
    var endhidden = a.find(".boxme li .endhidden");
    var location = a.find(".boxme li .location");
    var templates = a.find(".boxme li .template");
    var tags = a.find(".boxme li .tag");
    var o = a.find(".addition").val();
    var sortCondition = "sort:";
    var isSort = false;


    if (o.substring(0, sortCondition.length) === sortCondition) {
        isSort = true;
        o = o.replace(sortCondition, "");
        n.push({
            type: "sort",
            value: o,
            operation: getSortDirectionFromUI($j(this))
        });
    }

    if (o != null && o != "" && isSort == false) {

        o = o.replace("text:", "");
        n.push({
            type: "text",
            value: o,
            operation: getBooleanOperationFromUI($j(this))
        });
    }

    $j.each(customSort, function () {
        n.push({
            type: "sort",
            value: $j(this).text(),
            operation: getSortDirectionFromUI($j(this))
        });
    });

    $j.each(recent, function () {
        n.push({
            type: "recent",
            value: $j(this).text().split('|')[1],
            operation: getBooleanOperationFromUI($j(this))
        });
    });

    $j.each(starthidden, function () {
        n.push({
            type: "start",
            value: $j(this).text(),
            operation: getBooleanOperationFromUI($j(this))
        });
    });

    $j.each(endhidden, function () {
        n.push({
            type: "end",
            value: $j(this).text(),
            operation: getBooleanOperationFromUI($j(this))
        });
    });

    $j.each(location, function () {
      var title = $j(this).parent().attr('title').split('|');
      n.push({
            type: "location",
            value: title[1] || title[0],
            operation: getBooleanOperationFromUI($j(this))
        });
    });


    $j.each(tags, function () {
        n.push({
            type: "tag",
            value: ($j(this).parent().attr('title').split('|').length > 1) ? $j(this).parent().attr('title').split('|')[1] : $j(this).parent().attr('title').split('|')[0],
            operation: getBooleanOperationFromUI($j(this))
        });
    });

    $j.each(templates, function () {
        n.push({
            type: "template",
            value: ($j(this).parent().attr('title').split('|').length > 1) ? $j(this).parent().attr('title').split('|')[1] : $j(this).parent().attr('title').split('|')[0],
            operation: getBooleanOperationFromUI($j(this))
        });
    });

    return n;
}

function onSbClearClick() {
    $j('.sb_clear').toggle({
        display: 'inline'
    });

    if ($j.browser.msie) {
        $j(".boxme").css({ width: "100%" });
    }

    if ($j.browser.msie) {
        document.getElementById("token-input-demo-input-local").value = "";
    } else {
        $j(".addition").text("");
    }

    $j(".addition").val("");

    DetachPieElements('.token-input-token-facebook');

    $j(".boxme").children(".token-input-token-facebook").remove();
    scFixIeLayout();
};

function findAndRemove(array, property, value) {
    $j.each(array, function (index, result) {
        if (result[property] == value) {
            array.splice(index, 1);
        }
    });
    return array;
}

function findAndAlert(array, property, value) {
    var done = false;
    $j.each(array, function (index, result) {
        if (result[property] == value) {
            done = true;
        }
    });
    return done;
}

function DisableInception() {
    if ($j("#StartButton", parent.parent.parent.document.body).length > 0) {
        if ($j(".scEditorTabIcon", parent.parent.document.body).length > 0) {
            var contextTabs = $j(".scEditorTabIcon", parent.document.body);
            var disableSearch = false;
            $j.each(contextTabs, function () {
                if (this.src.indexOf("view.png") > 0) {
                    disableSearch = true;
                    $j(this.parentNode.parentNode).css("display", "none");
                    $j(this.parentNode.parentNode.nextElementSibling).css("display", "");
                }
                if (this.src.indexOf("view_add.png") > 0) {
                    disableSearch = true;
                    $j(this.parentNode.parentNode).css("display", "none");
                    $j(this.parentNode.parentNode.nextElementSibling).css("display", "");
                }
            });
            $j("#EditorFrames", parent.document.body).children()[0].style.display = "none";
            $j("#FContent", parent.document.body)[0].style.display = "";
        }
    }
}

function UpdatePieElements(selector) {
    if ($j.browser.msie) {
        $j(selector).each(function () {
            try {
                window.PIE.attach(this);
            } catch (e) {
            }
        });
    }
}

function DetachPieElements(selector) {
    if ($j.browser.msie) {
        $j(selector).each(function () {
            window.PIE.detach(this);
        });
    }
}

function establishViews() {
    var a = $j("#ui_element");
    var defaultViews = ["list", "grid"];  //TODO: Hardcoded Logic

    var views;
    jQuery.ajax({
        type: "POST",
        url: "/sitecore/shell/Applications/Buckets/ItemBucket.asmx/GetViews",
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (b) {
            views = b.d;
            $j.each(views, function (index, filter) {
                $j("#views").append("<a id=\"" + filter.ViewName + "\" class=\"" + filter.ViewName + " scView\" title=\"" + filter.ToolTip + "\"></a>");
                $j(".scView").click(function () {
                    FacetOn = false;
                    CurrentView = filter.ViewName;
                    CurrentFacetFilter = [];
                    OnlyFacets = [];
                    $j("#views a").removeClass('active');
                });
            });

            $j.each(views, function (index, filter) {
                $j("#" + filter.ViewName).click(function () {
                    CurrentView = filter.ViewName;
                    a.find(".sb_up").click();
                    pageNumber = 0;

                    $j.each(defaultViews, function (subIndex, subfilter) {
                        $j("." + subfilter).removeClass("active");
                    });
                    $j("#" + filter.ID).addClass("active");
                    $j('.content').css({ 'opacity': 1.0 });
                    $j("#ajaxBusy").css({ display: "block" });
                    retrieveFilters();
                    var n = buildQuery();
                    runQuery(n, pageNumber, h, g);
                    runFacet(n, pageNumber, meme, g);

                    $j(".navAlpha").html("");
                    $j(".slide-out-div").html("").prepend(LoadGifText);
                    $j("#ajaxBusyFacet").css({
                        display: "none",
                        margin: "0px auto",
                        width: "44px"
                    });
                });
            });
        }
    });
}


function ClickHeaderAndSearch(fieldName, value) {
    var classValue = $j('.sortDirection').attr('class');
    AddSortElement(fieldName, value);

    if (classValue === undefined) {
        DoSortDirectionAsc();
    }
    else {
        (Contains(classValue, "desc")) ? DoSortDirectionAsc() : DoSortDirectionDesc();
    }

    var n = buildQuery();
    runQuery(n, pageNumber, h, g);
}


function Contains(string, substring) {
    var result = false;

    if (string != null) {
        result = string.toLowerCase().indexOf(substring) >= 0;
    }
    return result;
}

function DoSortDirectionAsc() {
    $j('.sortDirection').css("background-image", "url(../Buckets/images/sort.gif)").addClass("asc").removeClass("desc");
}

function DoSortDirectionDesc() {
    $j('.sortDirection').css("background-image", "url(../Buckets/images/sortdesc.gif)").addClass("desc").removeClass("asc");
}

function AddSortElement(fieldName, value) {
    $j(".boxme .sort").parent().remove();
    var previousValue = $j(".addition").val();
    $j(".addition").val(fieldName + ":" + value);
    retrieveFilters();
    $j(".addition").val(previousValue);
}


function GetSearchQuery(windowFilterSearch) {
    var searchQuery = [];
    var searchFilters = new Array();
    $j.each(AllFilters, function () {
        if (this.ClientSideHook == "normal") {
            searchFilters.push(this.DisplayName);
        }
    });

    //I need to pull operation off the string
    //Look for regular filters
    $j.each(searchFilters, function () {
        var innerFilter = getGlobalQueryVariableArray(this, windowFilterSearch);
        $j.each(innerFilter, function () {
            searchQuery.push(this);
        });
    });

    var datebasedSearchFilters = new Array();
    $j.each(AllFilters, function () {
        if (this.ClientSideHook == "date") {
            datebasedSearchFilters.push(this.DisplayName);
        }
    });

    //You can only put only date range in
    //Look for date based filters
    $j.each(datebasedSearchFilters, function () {
        var innerFilter = getGlobalQueryVariable(this, windowFilterSearch);
        if (innerFilter != undefined) {
            if (innerFilter.length > 0) {
                searchQuery.push({
                    type: this,
                    value: resolveKnownDates(innerFilter),
                    operation: getGlobalQueryVariableBooleanOperation(this, windowFilterSearch),
                    friendlyName: resolveKnownDates(innerFilter)
                });
            }
        }
    });

    var idBasedSearches = new Array();
    $j.each(AllFilters, function () {
        if (this.ClientSideHook == "id") {
            idBasedSearches.push(this.DisplayName);
        }
    });

    //Look for id based filters
    $j.each(idBasedSearches, function () {
        var innerFilter = getGlobalQueryVariableArray(this, windowFilterSearch);
        if (!!innerFilter) {
          $j.each(innerFilter, function () {
            this.value = this.value.split('|')[1] || this.value.split('|')[0];
            searchQuery.push(this);
          });
        }
    });

    var parsedSearchFilters = new Array();
    $j.each(AllFilters, function () {
        if (this.ClientSideHook == "sort") {
            parsedSearchFilters.push(this.DisplayName);
        }
    });

    //Look for parsed filters
    $j.each(parsedSearchFilters, function () {
        var innerFilter = getGlobalQueryVariable(this, windowFilterSearch);
        if (innerFilter != undefined) {
            if (innerFilter.length > 0) {
                searchQuery.push({
                    type: this,
                    value: innerFilter,
                    operation: innerFilter.indexOf("desc") > -1 ? "desc" : "asc",
                    friendlyName: innerFilter
                });
            }
        }
    });

    var customSearchFilters = new Array();
    $j.each(AllFilters, function () {
        if (this.ClientSideHook == "custom") {
            customSearchFilters.push(this.DisplayName);
        }
    });

    //Look for parsed filters
    $j.each(customSearchFilters, function () {
        var innerFilter = getGlobalQueryVariableArray(this, windowFilterSearch);
        if (innerFilter != undefined) {
            if (innerFilter.length > 0) {
                $j.each(innerFilter, function () {
                    searchQuery.push(this);
                });
            }
        }
    });

    return searchQuery;
}

function addFilterGlobal() {
    var searchQuery = GetSearchQuery(window.filterForAllSearch);

    if (searchQuery.length > 0) {

        $j.each(searchQuery, function () {
            var d = this.value;
            var friendlyName = this.friendlyName;
            var dateDescription = "";
            var hidden = "";
            if (this.type == "start" || this.type == "end") {
                dateDescription = "<span>" + upperFirstLetter(this.type) + " Date" + "</span>";
                hidden = "hidden";
            }
            
            if (this.type == "sort") {
                $j(".boxme").prepend('<li class="token-input-token-facebook" style="opacity:0.3;" title="' + d + '"><span  title="' + '' + '" style="background: url(\'images/' + this.type + this.operation + '.png\') no-repeat center center;padding: 0px 11px;" class="sortDirection should desc"></span><span>sort:</span><span class="' + this.type + '" style="text-overflow: ellipsis;color:black;max-width: 411px;overflow: hidden;vertical-align:top;">' + friendlyName + '</span><span class="token-input-delete-token-facebook remove" title="' + '' + '">×</span></li>');
            }
            else {
                $j(".boxme").prepend('<li class="token-input-token-facebook-noremove" style="opacity:0.3;" title="' + d + '"><span style="background: url(\'images/' + this.type + this.operation + '.png\') no-repeat center center;padding: 0px 11px;" class="booleanOperation ' + this.operation + '"></span>' + dateDescription + '<span style="text-overflow: ellipsis;color:black;max-width: 411px;overflow: hidden;vertical-align:top;" class="' + this.type + hidden + '">' + friendlyName + '</span><span class="token-input-delete-token-facebook noremove"></span></li>');
            }
        });

        window.CurrentFacetFilter = [];
        window.OnlyFacets = [];
        window.filterForAllSearch = '';
    }

    var cleanQuery = new Array();
    $j.each(searchQuery, function () {
        cleanQuery.push({
            type: this.type,
            value: this.value,
            operation: this.operation
        });
    });

    return cleanQuery;
}

$j.fn.watch = function (props, callback, timeout) {
    if (!timeout) timeout = 10;
    return this.each(function () {
        var el = $j(this),
            func = function () {
                __check.call(this, el);
            },
            data = {
                props: props.split(","),
                func: callback,
                vals: []
            };
        $j.each(data.props, function (i) {
            data.vals[i] = el.css(data.props[i]);
        });
        el.data(data);
        if (typeof (this.onpropertychange) == "object") {
            el.bind("propertychange", callback);
        } else if ($j.browser.mozilla) {
            el.bind("DOMAttrModified", callback);
        } else {
            setInterval(func, timeout);
        }
    });

    function __check(el) {
        var data = el.data(),
            changed = false;
        for (var i = 0; i < data.props.length; i++) {
            var temp = el.css(data.props[i]);
            if (data.vals[i] != temp) {
                data.vals[i] = temp;
                changed = true;
                break;
            }
        }

        if (changed && data.func) {
            data.func.call(el, data);
        }
    }
};

function scFixIeLayout() {
    if (!$j.browser.msie) return;
    var boxme = $j(".boxme");
    if (boxme.length == 0) return;

    if (boxme.is(':hidden')) {
        return;
    }

    var height = parseInt(boxme.height());
    if (height == 0) {
        return;
    }

    if (height < 0) {
        $j(".sb_clear").css("padding-bottom", "");
        $j(".sb_down").css("padding-bottom", "");
        $j(".sb_up").css("padding-bottom", "");
        $j(".sb_search").css("padding-bottom", "");
        return;
    }

    $j(".sb_clear").css("padding-bottom", height - 10);
    $j(".sb_down").css("padding-bottom", height - 8);
    $j(".sb_up").css("padding-bottom", height - 8);
    $j(".sb_search").css("padding-bottom", height - 10);
}

String.prototype.scFormat = function () {
    var args = arguments;
    return this.replace(/\{(\d+)\}/g, function (m, n) { return args[n] || ''; });
};

function scHtmlEscape(value) {
    return String(value)
      .replace(/&/g, '&amp;')
      .replace(/"/g, '&quot;')
      .replace(/'/g, '&#39;')
      .replace(/</g, '&lt;')
      .replace(/>/g, '&gt;');
};

function scHtmlUnescape(value) {
    return String(value)
      .replace(/&quot;/g, '"')
      .replace(/&#39;/g, "'")
      .replace(/&#039;/g, "'")
      .replace(/&lt;/g, '<')
      .replace(/&gt;/g, '>')
      .replace(/&amp;/g, '&');
};

function __includeAdditionalParameters(parameters) {
    var database = scGetURLParameter('sc_content');
    if (database) {
        parameters.sc_content = database;
    }
}

function scGetURLParameter(name, wnd) {
    if (!wnd) {
        wnd = window;
    }

    var value = (RegExp(name + '=' + '(.+?)(&|$)').exec(wnd.location.search) || [, null])[1];
    if (value) {
        return value;
    }

    if (wnd.top && wnd.top != wnd) {
        return scGetURLParameter(name, wnd.top);
    }

    return null;
}

function __scCleanupProperties(arr) {
    var res = [];
    $j(arr).each(function (indx, elem) {
        res.push({
            type: elem.type,
            value: elem.value,
            operation: elem.operation
        });
    });

    return res;
}