
(function(){
	var something;

}())


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
	$.modal('<div style="background-color:708090;border:2px solid black">\
						<form action="" method="GET">\
								<h2>Enter new Task:</h2>\
								<label for="name">Name: </label>\
								<input id="namefield" type="text" name="Name" value="Task Name"/>\
						    <label for="description">Description: </label>\
								<input id=descriptionfield" type="text" name="Description" value="Task Description"/>\
								<input type="button" name="createTask" value="Create" onClick="saveTask(this.form)"/>\
							</form>\
          </div>');
};
var updateTaskModal = function (taskId, taskName, taskDescription, taskStatus) {
	$.modal('<div style="background-color:708090;border:2px solid black">\
						<form action="" method="GET">\
							<h2>Update Task</h2>\
							<label for="Name">Name: </label>\
							<input type="text" name="Name" value="'+ taskName + '"/>\
							<label for="Description">Description: </label>\
							<input type="text" name="Description" value="'+ taskDescription + '"/>\
							<input type="hidden" name="Id" value="'+ taskId + '"/>\
							<input type="hidden" name="Status" value="'+ taskStatus + '"/>\
							<input type="button" name="updateTasky" value="Update" onClick="updateTask(this.form)"/>\
						</form>\
          </div>');
};

var saveTask = function (task) {
	$.ajax({
		url: "newtask/" + task.Name.value + "/" + task.Description.value,
		async: false
	});
	window.location.reload();
};

var updateTask = function (task) {
	var result;
	$.ajax({
		url: "updatetask/" + task.Name.value + "/" + task.Description.value + "/" + task.Id.value + "/" + task.Status.value,
		async: false,
		success:function(json){
			result = json;
		}
	});
	console.log(result);
	//window.location.reload();
	return result;
};
var removeTask = function (id) {
	$.ajax({
		url: "removetask/" + id,
		async: false
	});
	window.location.reload();
};

