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
    
    liveClick('#removetask', function () {
        var id = $(this).data()["id"];
        ServiceApi.removeTask(id);
        return false;
    });

    liveClick('#updatetask', function () {
        var taskData = $(this).data();
        UiApi.updateTaskModal(taskData);
        return false;
    });

    liveClick('#newtaskmodal', function () {
        var array = $('#newtaskform').serializeArray();
        var data = arrayToSensibleObject(array);
        ServiceApi.saveTask(data);
        return false;
    });

    liveClick('#updatetaskmodal', function () {
        var array = $('#updatetaskform').serializeArray();
        var data = arrayToSensibleObject(array);
        ServiceApi.updateTask(data);
        return false;
    });

    $('#newtask').click(function () {
        UiApi.newTaskModal();
        return false;
    });
});