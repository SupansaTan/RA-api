SELECT
	"Task"."Id" AS "TaskId",
	"Law"."Title" AS "TaskTitle",
	"Location"."Name" AS "LocationName",
	"Task"."DueDate" AS "DueDate"
FROM "Task"
LEFT JOIN "Law" ON "Law"."Id" = "Task"."LawId"
LEFT JOIN "Location" ON "Location"."Id" = "Task"."LocationId"
WHERE "Task"."LocationId" = '_empLocationId';