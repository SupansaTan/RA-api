SELECT DISTINCT "NotifyDate" AS "date"
FROM "Notification"
WHERE "Notification"."EmpId" = '_employeeId'
ORDER BY "NotifyDate" DESC;