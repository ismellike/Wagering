export default {
    methods: {
        hostsString(hosts) {
            if (hosts == null)
                return null;
            const length = hosts.length;
            const cutoff = 4;
            if (length > cutoff) {
                return (hosts
                    .splice(0, cutoff)
                    .map((x) => x.user.userName)
                    .join(", ") +
                    ", +" +
                    (length - cutoff + 1) +
                    " more...");
            }
            return hosts.map((x) => x.user.userName).join(", ");
        },
    },
};
//# sourceMappingURL=HostsString.js.map