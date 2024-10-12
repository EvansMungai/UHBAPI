using UHB.Data;
using UHB.Models;
using UHB.Services;


namespace UHB.Helpers
{
    public class RouteResolutionHelper : IRouteResolutionHelper
    {
        private readonly IHostelService _hostelService;
        private readonly IRoomService _roomService;
        private readonly IStudentService _studentService;
        private readonly IApplicationService _applicationService;
        
        public RouteResolutionHelper(IApplicationService applicationService, IRoomService roomService, IHostelService hostelService, IStudentService studentService)
        {
            _roomService = roomService;
            _applicationService = applicationService;
            _hostelService = hostelService;
            _studentService = studentService;
        }
        public void addMappings(WebApplication app)
        {
            // Hostel Routes
            app.MapGet("/hostels", () => this._hostelService.GetHostels());
            app.MapGet("/hostels/{id}", (string id) => this._hostelService.GetHostel(id));
            app.MapPost("/hostels", (Hostel hostel) => this._hostelService.CreateHostel(hostel));
            //app.MapPut("/hostels/{id}", ([FromBody] Hostel hostel, int id) => HostelService.UpdateHostel(hostel, id));
            //app.MapDelete("/hostel/{id}", (int id) => HostelService.RemoveHostel(id));

            //// Student Routes
            app.MapGet("/students", () => this._studentService.GetStudents());
            app.MapGet("/student/{id}", (string id) => this._studentService.GetStudent(id));
            app.MapPost("/students", (Student student) => this._studentService.CreateStudent(student));
            //app.MapPut("/students/{id}", ([FromBody] Student student, string id) => StudentService.UpdateStudent(student, id));
            //app.MapDelete("/students/{id}", (string id) => StudentService.RemoveStudent(id));

            //// Room Routes
            app.MapGet("/rooms", () => this._roomService.GetRooms());
            app.MapGet("/rooms/{id}", (string id) => this._roomService.GetRoom(id));
            app.MapPost("/rooms", (Room room) => this._roomService.CreateRoom(room));
            //app.MapPut("/rooms/{id}", ([FromBody] Rooms room, string id) => RoomService.UpdateRoom(room, id));
            //app.MapDelete("/rooms/{id}", (string id) => RoomService.RemoveRoom(id));

            //// Applications routes
            app.MapGet("/applications", () => this._applicationService.GetApplications());
            app.MapGet("/applications/{id}", (int id) => this._applicationService.GetApplication(id));
            app.MapPost("/applications", (Application application) => this._applicationService.CreateApplication(application));
            //app.MapPut("/applications/{id}", ([FromBody] Applications application, int id) => ApplicationService.UpdateApplicationDetails(application, id));
            //app.MapPut("/applications/{id}/status", ([FromBody] string status, int id) => ApplicationService.UpdateApplicationStatus(status, id));
            //app.MapPut("/applications/{id}/room", ([FromBody] string room, int id) => ApplicationService.UpdateRoomNo(room, id));
            //app.MapDelete("/applications/{id}", (int id) => ApplicationService.RemoveApplication(id));
        }
    }
}
