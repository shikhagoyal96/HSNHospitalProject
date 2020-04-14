<h4>reference taken from in-class lectures done by Christine Bittle</h4>

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
   
<h4>Rest of the features was done by my other team members.</h4>

 
