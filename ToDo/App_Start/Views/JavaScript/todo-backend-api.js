$(function () {
    var liveClick = function (selector, handler) {
        $(document).on("click", selector, handler);
        return false;
        },
        arrayToSensibleObject = function (array) {
            return _.reduce(array, function (acc, item) {
                acc[item.name] = item.value;
                return acc;
            }, {});
        };

    liveClick("#removeduty", function () {
        var id = $(this).data()["id"];
        ServiceApi.remove(id, "/duty/remove", function(data) {
          //todo
        });
    });

    liveClick("#removeproject", function() {
        var id = $(this).data()["id"];
        ServiceApi.remove(id, "/project/remove", function(data) {
          //todo
        });
    });

    liveClick("#updateduty", function () {
        var dutyData = $(this).data();
        UiApi.genModal("#update-duty-modal-template", dutyData);
    });

    liveClick("#updateproject", function () {
        var projectData = $(this).data();
        UiApi.genModal("#update-project-modal-template", projectData);
    });

    liveClick("#newduty", function () {
        var projectData = $(this).data();
        UiApi.genModal("#new-duty-modal-template", projectData);
    });

    liveClick("#newdutymodal", function () {
        var array = $("#newdutyform").serializeArray(),
            data = arrayToSensibleObject(array);
        console.log(JSON.stringify(data));
        ServiceApi.modify(data, "/duty/new", function(data) {
          //todo
        });
        $.modal.close();
    });

    liveClick("#newprojectmodal", function () {
        var array = $("#newprojectform").serializeArray(),
            data = arrayToSensibleObject(array);

        ServiceApi.modify(data, "/project/new", function (data) {
            //todo
        });
        $.modal.close();
    });

    liveClick("#updatedutymodal", function () {
        var array = $("#updatedutyform").serializeArray(),
            data = arrayToSensibleObject(array);
        ServiceApi.modify(data, "/duty/update", function (data) {
            //todo
        });
        $.modal.close();
    });

    liveClick("#updateprojectmodal", function () {
        var array = $("#updateprojectform").serializeArray(),
            data = arrayToSensibleObject(array);
        ServiceApi.modify(data, "/project/update", function (data) {
            //todo
        });
        $.modal.close();
    });

    $("#newproject").click(function () {
        UiApi.genModal("#new-project-modal-template");
        return false;
    });
});
