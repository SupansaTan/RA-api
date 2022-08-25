SELECT 
	"Law"."Title" AS "LawTitle",
	"Notification"."Process" AS "Process",
	"Notification"."NotifyDate" AS "NotifyDate",
	"Notification"."Read" AS "Read"
FROM "Notification"
INNER JOIN "Task" ON "Task"."Id" = "Notiification"."TaskId"
INNER JOIN "Law" ON "Law"."Id" = "Task"."LawId"
WHERE "Notification"."EmpId" = '_employeeId';
