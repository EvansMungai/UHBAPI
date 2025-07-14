using UHB.Data;
using UHB.Features.ApplicationManagement.Models;
using UHB.Features.ApplicationManagement.Services;
using UHB.Features.HostelManagement.Hostel.Models;
using UHB.Features.HostelManagement.Hostel.Services;
using UHB.Features.HostelManagement.Room.Models;
using UHB.Features.HostelManagement.Room.Services;
using UHB.Features.StudentManagement.Models;
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
            app.MapGet("/", () => "Welcome the UHB API V2!");
            // Hostel Routes
            app.MapGet("/hostels", () => this._hostelService.GetHostels()).WithTags("Hostels").Produces(200).Produces(404).Produces<List<Hostel>>();
            app.MapGet("/hostel/{id}", (string id) => this._hostelService.GetHostel(id)).WithTags("Hostels").Produces(200).Produces(404).Produces<Hostel>();
            app.MapPost("/hostel", (Hostel hostel) => this._hostelService.CreateHostel(hostel)).WithTags("Hostels").Produces(200).Produces(404).Produces<Hostel>();
            app.MapPut("/hostel/{id}", (Hostel hostel, string id) => this._hostelService.UpdateHostel(hostel, id)).WithTags("Hostels").Produces(200).Produces(404).Produces<Hostel>();
            app.MapDelete("/hostel/{id}", (string id) => this._hostelService.RemoveHostel(id)).WithTags("Hostels").Produces(200).Produces(404).Produces<Hostel>();

            //// Student Routes
            app.MapGet("/students", () => this._studentService.GetStudents()).WithTags("Students").Produces(200).Produces(404).Produces<List<Student>>();
            app.MapGet("/student/{id}", (string id) => this._studentService.GetStudent(id)).WithTags("Students").Produces(200).Produces(404).Produces<Student>();
            app.MapPost("/student", (Student student) => this._studentService.CreateStudent(student)).WithTags("Students").Produces(200).Produces(404).Produces<Student>();
            app.MapPut("/student/{id}", (Student student, string id) => this._studentService.UpdateStudent(student, id)).WithTags("Students").Produces(200).Produces(404).Produces<Student>();
            app.MapDelete("/student/{id}", (string id) => this._studentService.RemoveStudent(id)).WithTags("Students").Produces(200).Produces(404).Produces<Student>();

            //// Room Routes
            app.MapGet("/rooms", () => this._roomService.GetRooms()).WithTags("Rooms").Produces(200).Produces(404).Produces<List<Room>>();
            app.MapGet("/room/{id}", (string id) => this._roomService.GetRoom(id)).WithTags("Rooms").Produces(200).Produces(404).Produces<Room>();
            app.MapPost("/room", (Room room) => this._roomService.CreateRoom(room)).WithTags("Rooms").Produces(200).Produces(404).Produces<Room>();
            app.MapPut("/room/{id}", (Room room, string id) => this._roomService.UpdateRoom(room, id)).WithTags("Rooms").Produces(200).Produces(404).Produces<Room>();
            app.MapDelete("/room/{id}", (string id) => this._roomService.RemoveRoom(id)).WithTags("Rooms").Produces(200).Produces(404).Produces<Room>();

            //// Applications routes
            app.MapGet("/applications", () => this._applicationService.GetApplications()).WithTags("Applications").Produces(200).Produces(404).Produces<List<Application>>();
            app.MapGet("/accepted-applications", () => this._applicationService.GetAcceptedApplications()).WithTags("Applications").Produces(200).Produces(404).Produces<List<Application>>();
            app.MapGet("/rejected-applications", () => this._applicationService.GetRejectedApplications()).WithTags("Applications").Produces(200).Produces(404).Produces<List<Application>>();
            app.MapGet("/application/{id}", (int id) => this._applicationService.GetApplication(id)).WithTags("Applications").Produces(200).Produces(404).Produces<Application>();
            app.MapPost("/application", (Application application) => this._applicationService.CreateApplication(application)).WithTags("Applications").Produces(200).Produces(404).Produces<Application>();
            app.MapPut("/application/{id}", (Application application, int id) => this._applicationService.UpdateApplicationDetails(application, id)).WithTags("Applications").Produces(200).Produces(404).Produces<Application>();
            app.MapPut("/application/{id}/status", (string status, int id) => this._applicationService.UpdateApplicationStatus(status, id)).WithTags("Applications").Produces(200).Produces(404).Produces<Application>();
            app.MapPut("/application/{id}/room", (string room, int id) => this._applicationService.UpdateRoomNo(room, id)).WithTags("Applications").Produces(200).Produces(404).Produces<Application>();
            app.MapDelete("/application/{id}", (int id) => this._applicationService.RemoveApplication(id)).WithTags("Applications").Produces(200).Produces(404).Produces<Application>();
        }
    }
}
