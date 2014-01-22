
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
			success: function (json) {
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
