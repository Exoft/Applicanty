export const translations = {
    'app': {
        'applicanty': 'Applicanty',
        'english': 'Англійська',
        'ukrainian': 'Українська',
        'dashboard': 'Панель приладів',
        'vacancies': 'Вакансії',
        'lowerLimit': 'Від',
        'upperLimit': 'До',
        'search': 'Пошук',
        'profile': 'Профіль',
        'settings': 'Налаштування',
        'logOut': 'Вийти',
        'language': 'Мова',
        'candidates': 'Кандидати',
    },

    'vacancyList': {
        'add': 'Додати',
        'setActive': 'Активувати',
        'setArchived': 'Архівувати',
        'setDeleted': 'Видалити',
        'show': 'Показати',
        'title': 'Назва',
        'experienceLevels': 'Рівень Досвіду',
        'priority': 'Пріоритет',
        'status': 'Статус',
        'placeholderVacancyListDataGrid': 'Вакансій не знайдено!',
        'activate': 'Активувати',
        'archive': 'Архівувати',
        'delete': 'Видалити',
        'candidates': 'Кандидати',
        'vacancies' : 'вакансій',
        'of': 'з',
    },

    'vacancyPage': {
        'title': 'Назва',
        'createdAt': 'Дата ствонення',
        'experience': 'Досвід',
        'priority': 'Пріоритет',
        'technologies': 'Технології',
        'vacancyDescription': 'Опис вакансії',
        'potentialCandidates': 'Потенційні кандидати',
        'placeholderPotentialCandidatesListDataGrid': 'Потенційних кандидатів не знайдено!',
        'candidates': 'Кандидати',
        'viewDetails': 'Докладніше',
        'candidatesFooter': 'кандидадів',
        'of': 'з',
        'save': 'Зберегти',
        'cancel': 'Закрити',
        'add': 'Додати',
        'delete': 'Видалити',
        'stage': 'Етап',
        'attachVacancyToCandidate': 'Призначати вакансії кандидата',
        'jobDescription': 'Опис роботи',
        'comments': 'Коментарі',
        'commentText': 'Новий коментар',
    },

    'candidateList': {
        'firstName': 'Прізвище',
        'lastName': 'Ім\'я',
        'age': 'Вік',
        'email': 'Електронна адреса',
        'add': 'Додати',
        'setActive': 'Активувати',
        'setArchived': 'Архівувати',
        'setDeleted': 'Видалити',
        'show': 'Показати',
        'experienceLevels': 'Рівень Досвіду',
        'placeholderCandidateListDataGrid': 'Кандидатів не знайдено',
        'status': 'Статус',
        'activate': 'Активні',
        'archive': 'Архівовані',
        'delete': 'Видалені',
        'users': 'кандидатів',
        'of': 'з',
    },

    'candidatePage': {
        'firstName': 'Прізвище',
        'lastName': 'Ім\'я',
        'email': 'Електронна адреса',
        'skype': 'Скайп',
        'linkedIn': 'Лінкедін',
        'phone': 'Телефон',
        'addFile': 'Додати файл',
        'experience': 'Досвід',
        'technologies': 'Технології',
        'save': 'Зберегти',
        'cancel': 'Закрити',
        'add': 'Додати',
        'delete': 'Видалити',
        'stage': 'Етап',
        'attachVacancyToCandidate': 'Призначати вакансії кандидата',
        'vacancy': 'Вакансії',
        'cv': 'Резюме',
    },

    'settings': {
        'technologies': 'Технології',
        'save': 'Зберегти',
        'cancel': 'Закрити',
        'addTechnology': 'Додати технологію',
        'deleteTechnology': 'Видалити технологію',
        'attachNewTechnology': 'Прикріпити нову технологію',
    },

    'notfoundСomponent': {
        'nothingFound': 'Вибачте, нічого не знайдено',
        'youRequestedCouldNotBeFound': 'Сторінку не була знайдено на нашому сервері',
        'error': '404 Error',
        'homepage': 'Домашня сторінка'
    },

    'authorization': {
        'confirmationLinkSentToYourEmail': 'Підтвердження, надіслане на вашу електронну адресу',
        'pleaseCheckYourInbox': 'Перевірте вашу поштову скриньку',
        'yourEmailIseingConfimed': 'Ваш електронний лист підтверджується.',
        'emailSuccessfullyValidated.': 'Email успішно перевірено.',
        'navigatingToLoginIn.': 'Навігація, щоб увійти в систему',
        'signUp.': 'Зареєструватися',
        'welcomeTo.': 'Вітаємо в'
    },

    'enums': {
        'statusType': {
            'active': 'Активні',
            'archived': 'Архівовані',
            'deleted': 'Видалені'
        },

        'vacancyStage': {
            'cv': 'Резюме',
            'interview': 'Співбесіда',
            'customerInterview': 'Співбесіда з замовником',
            'technicalInterview': 'Технічна співбесіда',
            'offer': 'Пропозиція',
            'hired': 'Найнятий',
            'rejected': 'Відмовлено',
            'didNotCome': 'Не прийшов',
            'failedInterview': 'Провалив співбесіду'
        },

        'expirience': {
            'trainee': 'Trainee',
            'junior': 'Junior',
            'middle': 'Middle',
            'senior': 'Senior'
        },

        'priority': {
            'low': 'Низький',
            'medium': 'Середній',
            'high': 'Високий'
        }
    },

    'validation': {
        'required': 'Це поле є обов\'язковим',
        'min': 'Введене значення має бути більшим',
        'invalidEmail': 'Введене значення недійсна електронна адреса',
        'passwordsDoNotMatch': 'Пароль не збігається',
        'invalidTechnologiesCount': 'Кількість технологій не може бути менше двох',
        'invalidLowerDateLimit': 'Нижня межа дати не може бути пізнішою, ніж верхня межа дати',
        'invalidLowerAgeLimit': 'Нижня межа віку не може перевищувати межі верхньої вікової категорії'
    },

    'notificationMessage': {
        'experienceLoadError': 'Помилка завантаження списку рівнів досвіду.',
        'priorityLoadError': 'Помилка завантаження списку пріоритетів.',
        'statusLoadError': 'Помилка завантаження списку статусів.',
        'vacanciesListLoadError': 'Помилка сталась під час завантаження списку вакансій.',
        'vacancyChangeStatusSucces': 'Статус вакансії змінено успішно.',
        'vacanciesChangeStatusSucces': 'Статус вакансій змінено успішно.',
        'vacancyChangeStatusError': 'Помилка сталась під час зміни статусу вакансії.',
        'vacancyDetailsLoadError': 'Деталі про вакансію не завантажено.',
        'technologiesLoadError': 'Список технології не завантажено.',
        'vacancyStageLoadError': 'Етапи вакансій не завантажено.',
        'vacanciesLoadError': 'Вакансії не завантажені.',
        'createVacancyError': 'Помилка сталась під час створення нової вакансії.',
        'updateVacancyError': 'Помилка сталась під час збереження змін про вакансію.',
        'vacancyStagesCountLoadError': 'Помилка сталась під час завантаження кількості кандидатів на етапах вакансії',
        'candidateChangeStatusError': 'Помилка зміни статусу кандидата',
        'createCandidateError': 'Помилка сталась під час стоврення нового кандидата.',
        'candidateDetailsLoadError': 'Деталі про кандидата не завантажено.',
        'candidateChangeStatusSucces': 'Статус кандидата змінено успішно.',
        'candidatesChangeStatusSucces': 'Статус кандидатів змінено успішно.',
        'candidatesListLoadError': 'Помилка сталась під час завантаження списку кандидатів',
        'loginOrPasswordEnterEdincorectly': 'login or password entered incorrectly',
        'attachCandidateStageToVacancy': 'Vacancy and stage successfully added',
        'attachCandidateStageToVacancyError': 'Error adding a vacancy',
        'internetServiceError': 'Internal Server Error',
        'unauthorizedError': 'Час сесії вичерпано.',
        'signInError': 'Помилка сталась під час авторизації',
        'forbiddenError': 'Логін або пароль введені неправильно',
        'potentialCandidatesLoadError': 'Помилка сталась під час завантаження вибору потенційних кандидатів'
    }
};
