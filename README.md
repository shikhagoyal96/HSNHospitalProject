HSN Hospital Project
The Team
Christopher Maeda (N00768018)
What I have done:
Features worked on was Job Post and Donation

CRUD implemented for Department, Job Post, and Donation with feedback to user

Validation implemented for the Department, Job Post, and Donation

Implement view model for the Department, Job Post, and Donation

Implement admin, anonymous, and user for different control and view for Department, Job Post, and Donation

For Donation feature implement using Stripe API for the payment

Set up meeting with the professor and deadline for the team

Created the wireframe for my features

Created the ERD diagram with the team

Jashanpreet Kaur (N01289670)
What I have done:
Doctor Directory and Book an appointment features:
Doctor Directory:
Doctor Directory Database (Models/Doctors.cs)
Doctor Directory Controller (Controllers/DoctorsControllers.cs)
Doctor Directory create, read, update and delete views (Views/Add.cshtml, Views/DeleteConfirm.cshtml, Views/List.cshtml, Views/Show.cshtml, Views/Update.cshtml)
Book an Appointment
Book an Appointment Database (Models/Appointments.cs)
Book an Appointment Controller (Controllers/AppointmentsControllers.cs)
Book an Appointment create, read, update and delete views (Views/Add.cshtml, Views/DeleteM.cshtml, Views/Edit.cshtml, Views/List.cshtml, Views/Show.cshtml)
Book an Appointment is related to the patient so I created:
Patients Database (Models/Patients.cs)
Patients Controller (Controllers/PatientsControllers.cs)
Patients read, create, update and delete views (Views/Add.cshtml, Views/Edit.cshtml, Views/List.cshtml, Views/Show.cshtml)
Error Page(Access Denied):
Error Controller (Controllers/ErrorController.cs)
Error View (Views/Index.cshtml)
ViewModels
To show the Departments on the Doctor's page (Models/ViewModels/DoctorDepartment.cs)
To show the booked appointments (Models/ViewModel/AddAppointment.cs)
Logs Class
create a Logs class (Logs/LoggedIn.cs)
This class check the user is logged in or not if logged in then its a user or admin.
Create wireframes and user stories
Joshua Silveira (N01404730)
What I have done:
Articles Model (Models/Articles.cs)
Activity Records controller (Controllers/ArticleController.cs)
Activity Records list, create, update(contains a delete button with a confirmation modal) views (Views/Articles/Create.cshtml, Views/Articles/Update.cshtml, Views/Articles/Index.cshtml)
Added a Rich text editor to both the update and create views in (Views/Articles/Create.cshtml, Views/Articles/Update.cshtml)
Articles Model (Models/Articles.cs)
Created a transulent logo image in adobe illustrator from the orignal HSN sudbury logo from https://www.facebook.com/HSNSudbury/photos/a.244932238896630/1572964369426737/?type=1&theater
implemented a site design (Shared/_layout.cshtml)
site design can be viewed in the root github folder (HSNwebsite.jpg)
created wireframes for my feature
Created user stories for my feature
Sam Bebenek (N00831998)
What I have done:
Setting up the visual studio project and github repo
Adding 'is_admin' column to users table
Activity Graph and Image Gallery features including:
Activity Records model (Models/ActivityRecords.cs)
Activity Records controller (Controllers/ActivityRecordsController.cs)
Activity Records list, create, update, and delete views (Views/ActivityRecords/Create.cshtml, Views/ActivityRecords/Delete.cshtml, Views/ActivityRecords/DeleteMultiple.cshtml, Views/ActivityRecords/Edit.cshtml, Views/ActivityRecords/Index.cshtml)
_StartGraph partial view (Views/Shared/_StartGraph.cshtml)
GraphGenerator script (Scripts/GraphGenerator.js)
GraphValueHolder helper class, a class that stores ActivityRecords table information so that it can be passed to the GenerateGraph script (Helpers/LoggedInChecker.cs)
Adding the graph and AJAX script to the home page (Views/Home/Index.cshtml)

Gallery Images model (Models/GalleryImages.cs)
Gallery Images controller (Controllers/GalleryImagesController.cs)
Gallery Images list, create, delete, and edit views (Views/GalleryImages/Create.cshtml, Views/GalleryImages/Edit.cshtml, Views/GalleryImages/Delete.cshtml, Views/GalleryImages/Index.cshtml)
_ShowImage partial view, to fill the modal window on the Gallery Images index page (Views/Shared/_ShowImage.cshtml)
LoggedInChecker class, a class that contains methods that can determine if a user is logged in, if a user is an admin, or what the id of the logged in user is (Helpers/LoggedInChecker.cs)
Created wireframes for my features and contributed to the documentation inside the Documentation folder.
The repo notes at the end of this README file, consisting of tips for anyone who has or is trying to avoid merge errors.

<h3>Shikha Goyal (N01329988)</h3>
<h4>Features :</h4>

1. Faq <h4>* CRUD with foreign key </h4>
   model - faq.cs<br/>
   controller - FaqController<br/>
   views - Details, DetailsUser, Edit, Show, Create<br/>
   foreign key - departmentId(department table)<br/>
   relationship - one department to many faqs<br/>
   extra - search and pagination<br/>
   
2. Feedback <h4>* Basic CRUD with no foreign key </h4>
   model - Feedback.cs<br/>
   controller - FeedbackController<br/>
   views - Details, Edit, Show, Create<br/>
   foreign key - none<br/>
   relationship - none<br/>
   extra - search and pagination<br/>
   
3. Userfeedback <h4>* Its is the improved version of the above feedback model as it involves the usage of foriegn key and viewmodel </h4>
   model - Userfeedback.cs<br/>
   viewmodel - UpdateUserfeedback.cs<br/>
   controller - UserfeedbackController<br/>
   views - Details, Edit, Show, Create<br/>
   foreign key - servicesId(services table)<br/>
   relationship - one service to many userfeedback<br/>
   extra - search and pagination<br/>
   Linq - Used<br/>

Repo Notes
If you are on a different version of the repo and are trying to get on the newest one OR you've pulled and tried to update the database but you got errors and need to start from scratch:
Copy your own feature's Model files, Controller, and and views and move them somewhere else where you'll remember them.

Delete your database for the HSNHospitalProject.

Delete your HSNHospitalProject visual studio project entirely (not including the files you've set aside in step 1).

Clone a fresh new version of the repo, open it and run update-datebase

IF THERE ARE NO ERRORS, continue:

Add your old copies of your model files to the Models folder.

Link them in the IdentityModels.cs context file like the other existing models are linked in that file.

PULL from the repo.

Add a migration, and update-database

Run the project, try a CRUD operation in someone else's feature, just make sure that normal site operation doesn't cause any errors.

IF THERE ARE NO ERRORS, continue:

Add your old copies of your Controller files and View files to the correct folders

Run the program and see if they work correctly

THERE ARE NO ERRORS, continue:

Pull again, update database again, run program again

IF AND ONLY IF THERE ARE NO ERRORS:

Push your code to the repo

If there are errors at any point when following these steps, let us know, but DO NOT PUSH YOUR CODE IF THERE ARE ERRORS.

Some tips you should always follow to ensure smooth and merge-free development with a team over github:
-PULL EARLY AND PULL OFTEN. There is no such thing as pulling too much or too often. Doing so will make sure there are as little differences as possible from your local version and the master branch, meaning there is less of a chance for merge errors.

-Before adding any of your own migrations, ALWAYS PULL AND UPDATE-DATABASE FIRST. This will add someone else's migrations first and will maintain the order of migrations, so that there are no errors when updating the database. If you've pulled from the repo and ran update database and there are no errors, it should then be safe to add your migrations.

-If you have gotten ANY errors when doing the last two tips (pulling or updating the database), DO NOT PUSH YOUR CODE. Asp.net is really finnicky, and if your project is broken and you push, it is possible that it may break irreparably for anyone that pulls the repo in the future.

-ALWAYS PULL BEFORE PUSHING. No matter what. Github should stop you from pushing if there are any changes to pull, but it is better to be safe than sorry.

-from Sam's Email






 
