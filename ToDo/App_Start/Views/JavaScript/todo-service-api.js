function loadTask(id) {
	var results;
	$.ajax({
		url: "todo/app_start/controllers/iraven/loadtask/" + id,
		async: false,
		success: function (json) {
			results = json;
		}
	});
	return results;
};
var loadTasks = function () {
	var results;
	$.ajax({
		url: "todo/app_start/controllers/iraven/loadalltasks",
		async: false,
		success: function (json) {
			results = json;
		}
	});
	return results;
};
var newTaskModal = function () {
	$.modal('<form action="" method="GET">\
							<div>\
								<h2>Enter new Task:</h2></br>\
								<label for="name">Name: </label>\
								<input id="namefield" type="text" name="Name" value="Task Name"/>\
						    <label for="description">Description: </label>\
								<input id=descriptionfield" type="text" name="Description" value="Task Description"/>\
								<input type="button" name="createTask" value="Create" onClick="saveTask(this.form)"/>\
							</div>\
						</form>')
}
var updateTaskModal = function (taskId, taskName, taskDescription, taskStatus) {
	console.log("updateTaskModal()");
	$.modal('<form action="" method="GET">\
          <div>\
            <label for="name">Name: </label>\
						<input type="text" name="Name" value="'+ taskName + '"/>\
            <label for="description">Description: </label>\
						<input type="text" name="Description" value="'+ taskDescription + '"/>\
            <input type="hidden" name="Id" value="'+ taskId + '"/>\
            <input type="hidden" name="Status" value="'+ taskStatus + '"/>\
            <input type="button" name="updateTask" value="Update" onClick="updateTask(this.form)"/>\
          </div>\
        </form>');
}

var saveTask = function (task) {
	console.log(task.Name.value);
	console.log(task.Description.value);
	$.ajax({
		url: "newtask/" + task.Name.value + "/" + task.Description.value,
		async: false
	});
	window.location.reload();
};
var updateTask = function (task) {
	console.log(task.Description.value);
	console.log(task.Status.value);
	console.log(task.Id.value);
	console.log(task.Name.value);
	$.ajax({
		url: "updatetask/" + task.Name.value + "/" + task.Description.value + "/" + task.Id.value + "/" + task.Status.value,
		async: false
	});
};
var removeTask = function (id) {
	$.ajax({
		url: "removetask/" + id,
		async: false
	});
	window.location.reload();
};

