USE TaskManagerDB;


-- Delete existing tasks
DELETE FROM Tasks;

-- Reset identity column to 1 in T-SQL
DBCC CHECKIDENT ('Tasks', RESEED, 0);

-- Insert new tasks
INSERT INTO Tasks (Title, Description, DueDate)
VALUES 
    ('Submit report', 'Quarterly financial report.', '2024-03-15 17:00:00'),
    ('Project meeting', 'Discuss progress and plan next sprint.', '2024-03-20 10:30:00'),
    ('Review proposal', 'Evaluate client proposal.', '2024-03-25 14:00:00'),
    ('Training session', 'Attend training on new software tools.', '2024-03-28 09:00:00'),
    ('Prepare presentation', 'Organize data for board presentation.', '2024-04-02 15:45:00'),
    ('Support meeting', 'Discuss customer feedback and address issues.', '2024-04-07 11:30:00'),
    ('Project deadline', 'Ensure tasks completed before deadline.', '2024-04-15 12:00:00'),
    ('Networking event', 'Attend networking event.', '2024-04-20 18:30:00'),
    ('Performance reviews', 'Conduct team reviews.', '2024-04-28 13:00:00'),
    ('Retrospective meeting', 'Reflect on project and discuss improvements.', '2024-05-02 09:30:00'),
    ('Client meeting', 'Meet key client for updates and future collaboration.', '2024-05-10 14:15:00'),
    ('Task prioritization', 'Review and prioritize tasks with project team.', '2024-05-15 09:00:00'),
    ('Team building activity', 'Organize and participate in team-building activity.', '2024-05-20 12:30:00'),
    ('Budget review', 'Review and analyze budget with finance team.', '2024-05-25 16:45:00'),
    ('Product demo', 'Conduct demo of latest product features.', '2024-05-30 11:00:00');
