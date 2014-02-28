var InitApi = (function (){
    var projectPageInit = function () {
        ServiceApi.load(function (projects) {
          var element = $("#projectlist"),
              template = UiApi.compileTemplate("#project-template");

          element.append(template(projects["items"]));
          UiApi.shuffleItems(element);
        }, "projects");
      };
    var dutyPageInit = function () {
        var element = $("#dutylist"),
            template = UiApi.compileTemplate("#duty-template"),
            projectId = document.getElementById("project").getAttribute("data-id");
            shufflize = function(duties){
                element.append(template(duties["items"]));
                UiApi.shuffleItems(element);
                UiApi.shuffleFilter(element);
            }
            ServiceApi.loadMany(projectId, "/project/duties", shufflize);
    };

  return{
    dutyPageInit : dutyPageInit,
    projectPageInit : projectPageInit
  };
}());
