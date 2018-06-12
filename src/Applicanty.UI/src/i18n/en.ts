export const translations = {
    'app': {
        'applicanty': 'Applicanty',
        'english': 'English',
        'ukrainian': 'Ukrainian',
        'dashboard': 'Dashboard',
        'vacancies': 'Vacancies',
        'candidates': 'Candidates',
        'lowerLimit': 'From',
        'upperLimit': 'To',
        'search': 'Search',
        'profile': 'Profile',
        'settings': 'Settings',
        'logOut': 'Log Out',
        'language': 'Language',
    },

    'vacancyList': {
        'add': 'Add',
        'setActive': 'Set active',
        'setArchived': 'Set archived',
        'setDeleted': 'Set deleted',
        'show': 'Show',
        'title': 'Title',
        'experienceLevels': 'Experience Levels',
        'priority': 'Priority',
        'status': 'Status',
        'placeholderVacancyListDataGrid': 'We couldn\'t find any vacancies!',
        'activate': 'Activate',
        'archive': 'Archive',
        'delete': 'Delete',
    },
    'vacancyPage': {
        'title': 'Title',
        'createdAt': 'Created at',
        'experience': 'Experience',
        'priority': 'Priority',
        'technologies': 'Technologies',
        'vacancyDescription': 'Vacancy Description',
        'potentialCandidates': 'Potential candidates',
        'placeholderPotentialCandidatesListDataGrid': 'We couldn\'t find any potential candidates!',
        'candidates': 'Candidates',
        'viewDetails': ' View details',
        'candidatesFooter': 'candidates',
        'of': 'of',
        'cancel': 'Cancel',
        'save': 'Save',
        'add': 'Add',
        'delete': 'Delete',
        'stage': 'Stage',
        'attachVacancyToCandidate': 'Attach vacancy to candidate',
        'jobDescription': 'Job Description',
    },

    'candidateList': {
        'add': 'Add',
        'firstName': 'First Name',
        'lastName': 'Last Name',
        'age': 'Age',
        'email': 'Email',
        'setActive': 'Set active',
        'setArchived': 'Set archived',
        'setDeleted': 'Set deleted',
        'show': 'Show',
        'experienceLevels': 'Experience Levels',
        'status': 'Status',
        'placeholderCandidateListDataGrid': 'We couldn\'t find any candidates!',
        'activate': 'Activate',
        'archive': 'Archive',
        'delete': 'Delete',
    },

    'candidatePage': {
        'firstName': 'First Name',
        'lastName': 'Last Name',
        'email': 'Email',
        'skype': 'Skype',
        'linkedIn': 'LinkedIn',
        'phone': 'Phone',
        'addFile': 'AddFile',
        'experience': 'Experience',
        'technologies': 'Technologies',
        'cancel': 'Cancel',
        'save': 'Save',
        'add': 'Add',
        'delete': 'Delete',
        'stage': 'Stage',
        'attachVacancyToCandidate': 'Attach vacancy to candidate',
        'vacancy': 'Vacancy',
        'cv': 'CV',
    },

    'settings': {
        'technologies': 'Technologies',
        'cancel': 'Cancel',
        'save': 'Save',
        'addTechnology': 'Add technology',
        'deleteTechnology': 'Delete technology',
        'attachNewTechnology': 'Attach new tochnology',
    },

    'notfoundСomponent': {
        'nothingFound': 'Sorry, Nothing Found',
        'youRequestedCouldNotBeFound': 'The Page You Requested Could Not Be Found On Our Server',
        'error': '404 Error',
        'homepage': 'Homepage'
    },

    'authorization': {
        'confirmationLinkSentToYourEmail': 'Confirmation link sent to your email',
        'pleaseCheckYourInbox': 'Please check your inbox',
        'yourEmailIseingConfimed': 'Your email is being confimed. Hold a while please.',
        'emailSuccessfullyValidated.': 'Email successfully validated.',
        'navigatingToLoginIn.': ' Navigating to login in',
        'signUp': 'Sign Up',
        'welcomeTo.': 'Welcome To'
    },

    'enums': {
        'statusType': {
            'active': 'Active',
            'archived': 'Archived',
            'deleted': 'Deleted'
        },

        'vacancyStage': {
            'cv': 'CV',
            'interview': 'Interview',
            'customerInterview': 'Customer interview',
            'technicalInterview': 'Technical interview',
            'offer': 'Offer',
            'hired': 'Hired',
            'rejected': 'Rejected',
            'didNotCome': 'Did not come',
            'failedInterview': 'Failed interview'
        },

        'experience': {
            'trainee': 'Trainee',
            'junior': 'Junior',
            'middle': 'Middle',
            'senior': 'Senior'
        },

        'priority': {
            'low': 'Low',
            'medium': 'Medium',
            'high': 'High'
        }
    },

    'validation': {
        'required': 'This field is required',
        'min': 'Entered value must be greater',
        'invalidEmail': 'Entered value is not valid email address',
        'passwordsDoNotMatch': 'Password do not match',
        'invalidTechnologiesCount': 'Number of technologies can not be less two',
        'invalidLowerDateLimit': 'Lower date limit cannot be later than upper date limit',
        'invalidLowerAgeLimit': 'Lower age limit cannot be greater than upper age limit'
    },

    'notificationMessage': {
        'experienceLoadError': 'Experience list not loaded.',
        'priorityLoadError': 'Priority list not loaded.',
        'statusLoadError': 'Status list not loaded.',
        'vacanciesListLoadError': 'Error occurred during loading vacancy data',
        'vacancyChangeStatusSucces': 'Vacancy status changed successfully',
        'vacanciesChangeStatusSucces': 'Vacancies status changed successfully',
        'vacancyChangeStatusError': 'Error occurred during status change',
        'vacancyDetailsLoadError': 'Vacancy details not loaded.',
        'technologiesLoadError': 'Technology list not loaded.',
        'vacancyStageLoadError': 'Vacancy stages not loaded.',
        'vacanciesLoadError': 'Vacancies not loaded.',
        'createVacancyError': 'Error occurred during create new vacancy.',
        'updateVacancyError': 'Error occurred during saving vacancy changes.',
        'vacancyStagesCountLoadError': 'Error occurred during load vacancy stages count',
        'candidateChangeStatusError': 'Candidates status changed error',
        'createCandidateError': 'Error occurred during create new candidate.',
        'candidateDetailsLoadError': 'Candidate details not loaded.',
        'candidateChangeStatusSucces': 'Candidate status changed successfully',
        'candidatesChangeStatusSucces': 'Candidates status changed successfully',
        'candidatesListLoadError': 'Error occurred during loading candidate data',
        'loginOrPasswordEnterEdincorectly': 'login or password entered incorrectly',
        'attachCandidateStageToVacancy': 'Vacancy and stage successfully added',
        'attachCandidateStageToVacancyError': 'Error adding a vacancy',
        'internetServiceError': 'Internal Server Error',
        'unauthorizedError': 'Session time is over.',
        'signInError': 'Error occurred during authorization',
        'forbiddenError': 'Login or password entered incorrect',
        'potentialCandidatesLoadError': 'Error occurred during loading a potential candidates'
    }
}