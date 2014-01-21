todo-init-api = function(){
	var todo-service-api = new todo-service-api();
	var initTaskPage(){
		return todo-service-api.loadTasks();
	}
	return {
		initTaskPage: initTaskPage
	}
}