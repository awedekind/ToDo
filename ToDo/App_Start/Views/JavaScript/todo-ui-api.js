function generateTask(task) {
	var html = '<div id="tasks">\
								<ul>\
									<li each="var task in tasks">\
										<div style="background-color:DCDCDC;border:2px solid black>\
											<h3>${task.Name}</h3>\
											${task.Description}</br>\
											<a href="javascript:removeTask(\'${task.Id}\')">Remove</a>\
											<a href="javascript:removeTask(\'${task.Id}\',\'${task.Name}\', \'${task.Description}\', \'${task.Status}\')>Update</a>\
										</div>\
									</li>\
								</ul>\
							</div>';
	return html;
}

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