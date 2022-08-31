SELECT	"Logging"."Id" AS "Id",
		"Logging"."Process" AS "Process",
		"Logging"."Status" AS "Status",
		"Logging"."Notation" AS "Notation",
		"TaskKeyAct"."KeyActId" AS "KeyActId"
FROM "TaskKeyAct"
INNER JOIN "Logging" ON "Logging"."TaskKeyActId" = "TaskKeyAct"."Id"
WHERE "TaskKeyAct"."TaskId" = '_taskId' ;