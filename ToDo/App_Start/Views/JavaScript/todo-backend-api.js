$(function () {
    var liveClick = function (selector, handler) {
        $(document).on('click', selector, handler);
    },
        arrayToSensibleObject = function (array) {
            return _.reduce(array, function (acc, item) {
                acc[item.name] = item.value;
                return acc;
            }, {});
        };

    //liveClick('#projecttaskpage', function() {
    //    var id = $(this).data()["id"];
    //    ServiceApi.loadPage(id, "taskpage");
    //    return false;
    //});

    //liveClick('#projectspage', function () {
    //    console.log("liveclickin");
    //    ServiceApi.loadPage(null, "home");
    //    return false;
    //});

    liveClick('#removetask', function () {
        var id = $(this).data()["id"];
        ServiceApi.remove(id, "/taskremove", function(data) {
            console.log(data);
        });
        return false;
    });

    liveClick('#removeproject', function() {
        var id = $(this).data()["id"];
        console.log(id);
        ServiceApi.remove(id, "/projectremove", function(data) {
            console.log(data);
        });
        return false;
    });

    liveClick('#updatetask', function () {
        console.log($(this));
        var taskData = $(this).data();
        console.log(taskData);
        UiApi.genModal("#update-task-modal-template", taskData);
        return false;
    });

    liveClick('#updateproject', function () {
        var projectData = $(this).data();
        UiApi.genModal("#update-project-modal-template", projectData);
        return false;
    });

    liveClick('#newtask', function () {
        var projectData = $(this).data();
        console.log(JSON.stringify(projectData));
        UiApi.genModal("#new-task-modal-template", projectData);
        return false;
    });
    //$('#newtask').click(function () {
    //    UiApi.genModal("#new-task-modal-template");
    //    return false;
    //});
    liveClick('#newtaskmodal', function () {
        var array = $('#newtaskform').serializeArray(),
            data = arrayToSensibleObject(array);
        ServiceApi.modify(data, "/tasknew", function(data) {
            console.log(data);
        });
        $.modal.close();
        return false;
    });

    liveClick('#newprojectmodal', function () {
        var array = $('#newprojectform').serializeArray(),
            data = arrayToSensibleObject(array);

        ServiceApi.modify(data, "/projectnew", function (data) {
            console.log(data);
            //todo
        });
        $.modal.close();
        return false;
    });

    liveClick('#updatetaskmodal', function () {
        var array = $('#updatetaskform').serializeArray(),
            data = arrayToSensibleObject(array);
        ServiceApi.modify(data, "/taskupdate");
        $.modal.close();
        return false;
    });

    liveClick('#updateprojectmodal', function () {
        var array = $('#updateprojectform').serializeArray(),
            data = arrayToSensibleObject(array);
        ServiceApi.modify(data, "/projectupdate");
        $.modal.close();
        return false;
    });


    $('#newproject').click(function () {
        UiApi.genModal("#new-project-modal-template");
        return false;
    });
});