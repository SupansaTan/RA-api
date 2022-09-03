SELECT
	"Task"."Id" AS "TaskId",
	"Law"."Title" AS "TaskTitle",
	"Location"."Name" AS "LocationName"
FROM "Task"
LEFT JOIN "Law" ON "Law"."Id" = "Task"."LawId"
LEFT JOIN "Location" ON "Location"."Id" = "Task"."LocationId"
WHERE "Task"."Id" = '_taskId';