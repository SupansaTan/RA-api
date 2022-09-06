SELECT DISTINCT "NotifyDate"::date AS "date"
FROM "Notification"
WHERE "Notification"."EmpId" = '_employeeId'
ORDER BY "NotifyDate"::date DESC;